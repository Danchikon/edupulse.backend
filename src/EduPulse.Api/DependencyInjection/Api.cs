using System.Text.Json.Serialization;
using EduPulse.Api.GraphQl;
using EduPulse.Api.GraphQl.Interceptors;
using EduPulse.Infrastructure.Options;
using HotChocolate.Types.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace EduPulse.Api.DependencyInjection;

public static class Api
{
    public static IServiceCollection AddApi(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment environment
    )
    {
        services.AddCors();
        
        services.AddRestApi(environment, configuration);
        services.AddGraphQlApi<Query, Mutation>(environment);
        
        using var serviceProvider = services.BuildServiceProvider();

        var jsonWebKey = serviceProvider.GetRequiredService<JsonWebKey>();

        services
            .AddAuthentication()
            .AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters.IssuerSigningKey = jsonWebKey;
                jwtBearerOptions.TokenValidationParameters.ValidIssuer = "edupulse";
                jwtBearerOptions.TokenValidationParameters.ValidAudience = "edupulse";
                jwtBearerOptions.RequireHttpsMetadata = false;
            });
        
        services.AddAuthorization();

        return services;
    }
    
    public static IServiceCollection AddRestApi(
        this IServiceCollection services, 
        IHostEnvironment environment, 
        IConfiguration configuration
        )
    {
        services.ConfigureHttpJsonOptions(jsonOptions =>
        {
            jsonOptions.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        
        services.Configure<JsonOptions>(jsonOptions =>
        {
            jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        
        if (environment.IsProduction() is false)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(swaggerGenOptions =>
            {
                var swaggerOptions = configuration
                    .GetSection(SwaggerOptions.Section)
                    .Get<SwaggerOptions>()!;
                
                foreach (var serverUrl in swaggerOptions.ServersUrls)
                {
                    swaggerGenOptions.AddServer(new OpenApiServer
                    {
                        Url = serverUrl
                    });
                }
                
                swaggerGenOptions.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    In = ParameterLocation.Header, 
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey 
                });
                
                swaggerGenOptions.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    { 
                        new OpenApiSecurityScheme 
                        { 
                            Reference = new OpenApiReference 
                            { 
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer" 
                            } 
                        },
                        new string[] { } 
                    } 
                });
            });
        }

        return services;
    }
    
    public static IServiceCollection AddGraphQlApi<TQuery, TMutation>(this IServiceCollection services, IHostEnvironment environment) 
        where TQuery : class
        where TMutation: class
    {
        var requestExecutorBuilder = services.AddGraphQLServer();
        requestExecutorBuilder.AddHttpRequestInterceptor<ExceptionalHttpRequestInterceptor>();
        
        requestExecutorBuilder.SetPagingOptions(new PagingOptions
        {
            DefaultPageSize = 10,
            IncludeTotalCount = true,
            MaxPageSize = 100
        });
        
        requestExecutorBuilder.AddFiltering();
        requestExecutorBuilder.AddSorting();
        requestExecutorBuilder.AddProjections();
                
        requestExecutorBuilder.AllowIntrospection(environment.IsProduction() is false);
        requestExecutorBuilder.AddQueryType<TQuery>();
        // requestExecutorBuilder.AddMutationType<TMutation>();

        requestExecutorBuilder.AddMutationConventions(applyToAllMutations: true);

        return services;
    }
}