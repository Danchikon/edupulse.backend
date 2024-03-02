using EduPulse.Application.Common.Mediator;

namespace EduPulse.Application.Mediator.Commands.Tests;

public record CloseTestCommand : CommandBase
{
    public required Guid Id { get; init; }
}