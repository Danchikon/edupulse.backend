namespace EduPulse.Domain.Entities;

public class UserAnswerEntity
{
    public required Guid Id { get; init; }
    public required Guid StudentId { get; set; }
    public required Guid TestId { get; set; }
    public required Guid QuestionId { get; set; }
    public required string Value { get; set; }
    public required string CorrectValue { get; set; }
}