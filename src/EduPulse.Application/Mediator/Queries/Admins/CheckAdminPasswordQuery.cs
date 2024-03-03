using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Queries.Admins;

public record CheckAdminPasswordQuery : QueryBase<AdminDto?>
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}