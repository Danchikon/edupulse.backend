using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Commands.Tests;

public record CreateQuestionCommand : CommandBase<QuestionDto>
{
    public required string Title { get; init; }
    public CreateAnswerCommand[] CreateAnswerCommands { get; init; } = Array.Empty<CreateAnswerCommand>();
    public required CreateAnswerCommand CreateCorrectAnswerCommand { get; init; }
}