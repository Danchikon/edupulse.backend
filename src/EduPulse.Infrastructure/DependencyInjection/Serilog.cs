using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace EduPulse.Infrastructure.DependencyInjection;

public static class Serilog
{
    public static IHostBuilder ConfigureSerilog(this IHostBuilder hostBuilder)
    {
        const string serilogTemplate = "[{Timestamp:HH:mm:ss}][{Level:u3}][{SourceContext}] {Message:lj}{NewLine}{Exception}";
        
        hostBuilder.UseSerilog((hostBuilderContext, serviceProvider, loggerConfiguration) =>
        {
            loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration);
            loggerConfiguration.ReadFrom.Services(serviceProvider);
            loggerConfiguration.Enrich.FromLogContext(); 
            loggerConfiguration.WriteTo.Console(outputTemplate: serilogTemplate, theme: SystemConsoleTheme.Literate);
        });
        
        return hostBuilder;
    }
}