using EduPulse.Api;
using EduPulse.Api.DependencyInjection;
using EduPulse.Api.Rest.Middlewares;
using EduPulse.Application;
using EduPulse.Application.DependencyInjection;
using EduPulse.Infrastructure;
using EduPulse.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Host.UseSerilogLogging();

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);
builder.Services.AddApi(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseMiddleware<ExceptionalMiddleware>();

app.UseCors(corsPolicyBuilder =>
{
    corsPolicyBuilder.AllowAnyHeader();
    corsPolicyBuilder.AllowAnyOrigin();
    corsPolicyBuilder.AllowAnyMethod();
});

app.UseRouting();

if (app.Environment.IsProduction() is false)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGraphQL();
app.MapControllers();

await app.RunAsync();