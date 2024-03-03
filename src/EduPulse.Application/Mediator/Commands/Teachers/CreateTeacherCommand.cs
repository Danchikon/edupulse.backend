using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Commands.Teachers;

public record CreateTeacherCommand : CommandBase<TeacherDto>
{
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required Guid[] GroupIds { get; init; } = Array.Empty<Guid>();
    public required Guid[] SubjectIds { get; init; } = Array.Empty<Guid>();
}