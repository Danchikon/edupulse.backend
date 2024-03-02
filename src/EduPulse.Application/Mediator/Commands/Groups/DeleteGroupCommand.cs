using EduPulse.Application.Common.Mediator;

namespace EduPulse.Application.Mediator.Commands.Groups;

public record DeleteGroupCommand : CommandBase
{
    public required Guid Id { get; init; }
}