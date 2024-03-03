using System.Security.Claims;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Users;
using EduPulse.Infrastructure.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduPulse.Api.Rest.Routers;

public static class TeachersRouter
{
    public static IEndpointRouteBuilder MapTeacherRoutes(this IEndpointRouteBuilder endpoints)
    {
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
            .RequireAuthorization(policyBuilder => policyBuilder.RequireRole(UserRole.Teacher.ToString().ToLower()));
        
        return endpoints;
    }
}