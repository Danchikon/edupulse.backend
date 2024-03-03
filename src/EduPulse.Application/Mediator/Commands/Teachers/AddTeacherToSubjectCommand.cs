using EduPulse.Application.Common.Mediator;

namespace EduPulse.Application.Mediator.Commands.Teachers;

public record AddTeacherToSubjectCommand : CommandBase
{
    public required Guid TeacherId { get; init; }
    public required Guid SubjectId { get; init; }
}