using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Commands.UserAnswers;

public record CreateUserAnswerCommand : CommandBase<UserAnswerDto>
{
    public required Guid StudentId { get; init; }
    public required Guid TestId { get; init; }
    public required Guid QuestionId { get; init; }
    public required string Value { get; init; }
    public required string CorrectAnswer { get; init; }
}