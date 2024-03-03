namespace EduPulse.Domain.Entities;

public class UserAnswerEntity
{
    public required Guid UserId { get; set; }
    public required Guid TestId { get; set; }
    public required Guid QuestionId { get; set; }
    public required string Value { get; set; }
}