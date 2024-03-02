using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Queries.Users;

public record CheckUserPasswordQuery : QueryBase<UserDto?>
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}