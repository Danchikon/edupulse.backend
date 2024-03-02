using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Commands.Tests;

public record CreateTestCommand : CommandBase<TestDto>
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required DateTimeOffset OpensAt { get; init; }
    public required DateTimeOffset ClosesAt { get; init; }
    public CreateQuestionCommand[] CreateQuestionCommands { get; init; } = Array.Empty<CreateQuestionCommand>();
}