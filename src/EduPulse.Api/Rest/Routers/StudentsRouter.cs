using System.Security.Claims;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Users;
using EduPulse.Application.Mediator.Queries.Students;
using EduPulse.Infrastructure.Enums;
using EduPulse.Infrastructure.Implementations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduPulse.Api.Rest.Routers;

public static class StudentsRouter
{
    public static IEndpointRouteBuilder MapStudentsRoutes(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/sign-up",async (
            [FromBody] CreateStudentCommand command,
            IMediator mediator, 
            JsonWebTokenService jsonWebTokenService,
            CancellationToken cancellationToken
        ) =>
        {
            var userDto = await mediator.Send(command, cancellationToken);

            var token = jsonWebTokenService.Create(new Dictionary<string, object>
            {
                ["sub"] =  userDto.Id
            });
            
            return Results.Ok(new
            {
                User = userDto,
                AccessToken = token
            });
        });
        
        endpoints.MapPost("/sign-in",async (
            [FromBody] CheckStudentPasswordQuery query,
            IMediator mediator, 
            JsonWebTokenService jsonWebTokenService,
            CancellationToken cancellationToken
        ) =>
        {
            var userDto = await mediator.Send(query, cancellationToken);

            if (userDto is null)
            {
                return Results.Unauthorized();
            }
            
            var token = jsonWebTokenService.Create(new Dictionary<string, object>
            {
                ["sub"] =  userDto.Id
            });
            
            return Results.Ok(new
            {
                User = userDto,
                AccessToken = token
            });
        });
        
        endpoints.MapPost("/me/avatar", async (
                [FromForm] IFormFile avatar,
                IMediator mediator,
                HttpContext httpContext,
                CancellationToken cancellationToken
            ) =>
            {
                var userIdString = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userIdString is null)
                {
                    return Results.Forbid();
                }

                var userId = Guid.Parse(userIdString);

                await using var fileStream = avatar.OpenReadStream();

                var fileDto = new FileDto
                {
                    Stream = fileStream,
                    ContentType = avatar.ContentType
                };

                var command = new UploadStudentAvatarCommand
                {
                    StudentId = userId,
                    Avatar = fileDto
                };

                var uri = await mediator.Send(command, cancellationToken);

                return Results.Ok(uri);
            })
            .DisableAntiforgery()
            .RequireAuthorization(policyBuilder => policyBuilder.RequireRole(UserRole.Student.ToString().ToLower()));
        
        return endpoints;
    }
}