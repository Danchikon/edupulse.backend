using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Domain.Enums;

namespace EduPulse.Application.Mediator.Commands.Users;

public record UpdateTeacherCommand : CommandBase<TeacherDto>
{
    public required Guid Id { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
}