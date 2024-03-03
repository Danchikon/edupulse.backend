using System.Security.Claims;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Students;
using EduPulse.Application.Mediator.Commands.Teachers;
using EduPulse.Application.Mediator.Commands.Users;
using EduPulse.Application.Mediator.Queries.Students;
using EduPulse.Application.Mediator.Queries.Teachers;
using EduPulse.Infrastructure.Enums;
using EduPulse.Infrastructure.Implementations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduPulse.Api.Rest.Routers;

public static class TeachersRouter
{
    public static IEndpointRouteBuilder MapTeacherRoutes(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/sign-up",async (
            [FromBody] CreateTeacherCommand command,
            IMediator mediator, 
            JsonWebTokenService jsonWebTokenService,
            CancellationToken cancellationToken
        ) =>
        {
            var teacherDto = await mediator.Send(command, cancellationToken);
            
            foreach (var groupId in command.GroupIds)
            {
                await mediator.Send(new AddTeacherToGroupCommand
                {
                    GroupId = groupId,
                    TeacherId = teacherDto.Id
                }, cancellationToken);
            }
            
            foreach (var subjectId in command.SubjectIds)
            {
                await mediator.Send(new AddTeacherToSubjectCommand
                {
                    SubjectId = subjectId,
                    TeacherId = teacherDto.Id
                }, cancellationToken);
            }

            var token = jsonWebTokenService.Create(new Dictionary<string, object>
            {
                ["sub"] =  teacherDto.Id,
                ["role"] = UserRole.Teacher
            });
            
            return Results.Ok(new
            {
                User = teacherDto,
                AccessToken = token
            });
        });
        
        endpoints.MapPost("/sign-in",async (
            [FromBody] CheckTeacherPasswordQuery query,
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
                ["sub"] =  userDto.Id,
                ["role"] = UserRole.Teacher
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

                var teacherId = Guid.Parse(userIdString);

                await using var fileStream = avatar.OpenReadStream();

                var fileDto = new FileDto
                {
                    Stream = fileStream,
                    ContentType = avatar.ContentType
                };

                var command = new UploadTeacherAvatarCommand
                {
                    TeacherId = teacherId,
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