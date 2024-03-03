using EduPulse.Application.Common.Mediator;

namespace EduPulse.Application.Mediator.Commands.Teachers;

public record AddTeacherToGroupCommand : CommandBase
{
    public required  Guid TeacherId { get; init; }
    public required Guid GroupId { get; init; }
}