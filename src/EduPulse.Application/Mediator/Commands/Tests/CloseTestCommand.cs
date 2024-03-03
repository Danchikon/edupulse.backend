using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Commands.Tests;

public record CloseTestCommand : CommandBase<TestDto>
{
    public required Guid Id { get; init; }
}