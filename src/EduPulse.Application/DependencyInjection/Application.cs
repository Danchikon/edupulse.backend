using System.Reflection;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Mediator.Commands.Users;
using FastExpressionCompiler;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EduPulse.Application.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(mediatRServiceConfiguration =>
        {
            mediatRServiceConfiguration.Lifetime = ServiceLifetime.Scoped;
            
            
            mediatRServiceConfiguration.AddBehavior<TransactionalPipelineBehaviour<UploadUserAvatarCommand, Uri>>();
            mediatRServiceConfiguration.AddOpenBehavior(typeof(LoggingPipelineBehaviour<,>));
            
            mediatRServiceConfiguration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        
        services.AddMapster();
        TypeAdapterConfig.GlobalSettings.Compiler = expression => expression.CompileFast();
        
        return services;
    }
}