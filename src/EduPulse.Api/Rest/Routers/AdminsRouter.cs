using System.Security.Claims;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Students;
using EduPulse.Application.Mediator.Commands.Teachers;
using EduPulse.Application.Mediator.Commands.Users;
using EduPulse.Application.Mediator.Queries.Admins;
using EduPulse.Application.Mediator.Queries.Students;
using EduPulse.Application.Mediator.Queries.Teachers;
using EduPulse.Infrastructure.Enums;
using EduPulse.Infrastructure.Implementations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduPulse.Api.Rest.Routers;

public static class AdminsRouter
{
    public static IEndpointRouteBuilder MapAdminsRoutes(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/sign-in", (
            [FromBody] CheckAdminPasswordQuery query,
            JsonWebTokenService jsonWebTokenService
        ) =>
        {
            if (query.Password is not "superpower" && query.Password is not "admin@gmail.com")
            {
                return Results.Unauthorized();
            }

            var adminId = Guid.Parse("93624677-6d8c-4b2f-8a5c-92556b3f9b39");

            var token = jsonWebTokenService.Create(new Dictionary<string, object>
            {
                ["sub"] = adminId,
                ["role"] = UserRole.Admin.ToString()
            });

            return Results.Ok(new
            {
                Admin = new
                {
                    Id = adminId 
                },
                AccessToken = token
            });
        });

        return endpoints;
    }
}