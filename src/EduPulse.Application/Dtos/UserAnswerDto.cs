namespace EduPulse.Application.Dtos;

public record UserAnswerDto
{
    public required Guid UserId { get; init; }
    public required Guid TestId { get; init; }
    public required Guid QuestionId { get; init; }
    public required int Points { get; init; }
    public required string Value { get; init; }
    public required string CorrectAnswer { get; init; }
    public bool IsCorrect => Value == CorrectAnswer;
}