using System.Reflection;
using EduPulse.Application.Abstractions;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;
using EduPulse.Domain.Enums;
using EduPulse.Infrastructure.Enums;
using EduPulse.Infrastructure.Implementations;
using EduPulse.Infrastructure.Options;
using EduPulse.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Minio;
using Npgsql;


namespace EduPulse.Infrastructure.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment environment
    )
    {
        services.AddQuartzScheduling(configuration);
        services.AddMinioFilesStorage();
        services.AddPasswordHasher();
        services.AddJsonWebTokenService();
        services.AddSingleton<ITestScheduler, QuartzTestScheduler>();
        services.AddScoped<IEventsPublisher, CentrifugoOutboxEventsPublisher<EduPulseDbContext>>();
        services.AddKeyedSingleton("tests", new SemaphoreSlim(1));
        
        services.AddPostgresDataSource(dataSourceBuilderConfigurator =>
        {
            dataSourceBuilderConfigurator.MapEnum<TestStatus>();
        });
        
        services.AddEfPostgres<EduPulseDbContext>();
        services.AddEfRepositories<EduPulseDbContext>();
        services.AddEfUnitOfWork<EduPulseDbContext>();

        return services;
    }
    
    public static IServiceCollection AddEfUnitOfWork<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
    {
        services.AddScoped<IUnitOfWork, EfUnitOfWork<TDbContext>>();

        return services;
    }
    
    public static IServiceCollection AddEfRepositories<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
    {
        services.AddScoped<IRepository<GroupEntity>, EfRepository<GroupEntity, TDbContext>>();
        services.AddScoped<IRepository<StudentEntity>,  EfRepository<StudentEntity, TDbContext>>();
        services.AddScoped<IRepository<TeacherEntity>,  EfRepository<TeacherEntity, TDbContext>>();
        services.AddScoped<IRepository<TestEntity>, EfRepository<TestEntity, TDbContext>>();
        services.AddScoped<IRepository<SubjectEntity>,  EfRepository<SubjectEntity, TDbContext>>();
        services.AddScoped<IRepository<TeacherSubjectEntity>, EfRepository<TeacherSubjectEntity, TDbContext>>();
        services.AddScoped<IRepository<TeacherGroupEntity>,  EfRepository<TeacherGroupEntity, TDbContext>>();
        
        return services;
    }
    
    public static IServiceCollection AddPasswordHasher(this IServiceCollection services)
    {
        services
            .AddOptions<PasswordHasherOptions>()
            .BindConfiguration(PasswordHasherOptions.Section);
        
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        
        return services;
    }
    
    public static IServiceCollection AddJsonWebTokenService(this IServiceCollection services)
    {
        services
            .AddOptions<JsonWebTokenOptions>()
            .BindConfiguration(JsonWebTokenOptions.Section);

        services.AddSingleton<JsonWebKey>(provider =>
        {
            var options = provider.GetRequiredService<IOptions<JsonWebTokenOptions>>().Value;

            var json = File.ReadAllText(options.JsonWebKey);
            
            var jsonWebKey = new JsonWebKey(json);

            return jsonWebKey;
        });
        
        services.AddKeyedSingleton<SigningCredentials>("jwt", (provider, _) =>
        {
            var jsonWebKey = provider.GetRequiredService<JsonWebKey>();
            
            var signingCredentials = new SigningCredentials(jsonWebKey, SecurityAlgorithms.EcdsaSha256);

            return signingCredentials;
        });
        
        services.AddSingleton<JsonWebTokenHandler>(provider =>
        {
            var tokenHandler = new JsonWebTokenHandler
            {
                TokenLifetimeInMinutes = Convert.ToInt32(TimeSpan.FromDays(30).TotalMinutes)
            };

            return tokenHandler;
        });
        
        services.AddSingleton<JsonWebTokenService>();

        return services;
    }
    
    public static IServiceCollection AddMinioFilesStorage(this IServiceCollection services)
    {
        services
            .AddOptions<MinioOptions>()
            .BindConfiguration(MinioOptions.Section);
        
        services.AddSingleton<IMinioClient>(provider =>
        {
            var minioOptions = provider.GetRequiredService<IOptions<MinioOptions>>().Value;
            
            var client = new MinioClient()
                .WithEndpoint(minioOptions.Endpoint)
                .WithCredentials(minioOptions.AccessKey,  minioOptions.SecretKey)
                .Build();

            return client;
        });
        services.AddSingleton<IFilesStorage, MinioFilesStorage>();

        return services;
    }
    public static IServiceCollection AddEfPostgres<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
    {
        const string postgresMigrationsTableName = "ef_migrations";
        
        services.AddEf<TDbContext>((provider, dbContextOptionsBuilder) =>
        {
            var dataSourceBuilder = provider.GetRequiredService<NpgsqlDataSource>();
            
            dbContextOptionsBuilder.UseNpgsql(dataSourceBuilder, npgsqlDbContextOptionsBuilder =>
            {
                npgsqlDbContextOptionsBuilder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                npgsqlDbContextOptionsBuilder.MigrationsHistoryTable(postgresMigrationsTableName);
            });
        });

        return services;
    }
    
    public static IServiceCollection AddEf<TDbContext>(
        this IServiceCollection services, 
        Action<IServiceProvider, DbContextOptionsBuilder>? dbContextOptionsBuilderConfigurator = null
    ) where TDbContext : DbContext
    {
        services.AddPooledDbContextFactory<TDbContext>((provider, dbContextOptionsBuilder) =>
        {
            var environment = provider.GetRequiredService<IHostEnvironment>();
           
            if (environment.IsDevelopment())
            {
                dbContextOptionsBuilder.EnableSensitiveDataLogging();
                dbContextOptionsBuilder.EnableDetailedErrors();
            }
            
            dbContextOptionsBuilder.UseSnakeCaseNamingConvention();
            dbContextOptionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            
            dbContextOptionsBuilderConfigurator?.Invoke(provider, dbContextOptionsBuilder);
        });

        services.AddScoped<TDbContext>(provider =>
        {
            var dbContextFactory = provider.GetRequiredService<IDbContextFactory<TDbContext>>();
            
            var dbContext = dbContextFactory.CreateDbContext();
            
            return dbContext;
        });

        return services;
    }
    
    public static IServiceCollection AddPostgresDataSource(
        this IServiceCollection services, 
        Action<NpgsqlDataSourceBuilder>? dataSourceBuilderConfigurator = null
    ) 
    {
        const string postgresConnectionStringName = "Postgres";
        
        services.AddSingleton(provider =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var environment = provider.GetRequiredService<IHostEnvironment>();
            var connectionString = configuration.GetConnectionString(postgresConnectionStringName);
            
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);

            if (environment.IsDevelopment())
            {
                dataSourceBuilder.EnableParameterLogging();
            }
            
            dataSourceBuilderConfigurator?.Invoke(dataSourceBuilder);

            var dataSource = dataSourceBuilder.Build();
            
            return dataSource;
        });
        
        return services;
    }
    
}