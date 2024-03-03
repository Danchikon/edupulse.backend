using System.Data;
using EduPulse.Api.DependencyInjection;
using EduPulse.Api.Rest.Middlewares;
using EduPulse.Api.Rest.Routers;
using EduPulse.Application.DependencyInjection;
using EduPulse.Infrastructure;
using EduPulse.Infrastructure.DependencyInjection;
using EduPulse.Infrastructure.Options;
using EduPulse.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Serilog;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Host.UseSerilogLogging();

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);
builder.Services.AddApi(builder.Configuration, builder.Environment);

var app = builder.Build();

await using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
var context = serviceScope.ServiceProvider.GetRequiredService<EduPulseDbContext>();

await context.Database.MigrateAsync();

if (context.Database.GetDbConnection() is NpgsqlConnection npgsqlConnection)
{
    if (npgsqlConnection.State is not ConnectionState.Open)
    {
        await npgsqlConnection.OpenAsync();
    }
    
    try
    {
        await npgsqlConnection.ReloadTypesAsync();
    }
    finally
    {
        await npgsqlConnection.CloseAsync();
    }

}

app.UseCors(corsPolicyBuilder =>
{
    corsPolicyBuilder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionalMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(swaggerUiOptions =>
    {
        var swaggerOptions = app.Configuration
            .GetSection(SwaggerOptions.Section)
            .Get<SwaggerOptions>()!;

        swaggerUiOptions.RoutePrefix = swaggerOptions.RoutePrefix;
        
        foreach (var swaggerEndpoint in swaggerOptions.Endpoints)
        {
            swaggerUiOptions.SwaggerEndpoint(swaggerEndpoint.Url, swaggerEndpoint.Name);
        }
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL();

var apiGroup = app.MapGroup("api");

apiGroup
    .MapGroup("students")
    .MapStudentsRoutes();

apiGroup
    .MapGroup("teachers")
    .MapTeacherRoutes();

app.Run();