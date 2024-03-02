namespace EduPulse.Domain.Entities;

public class AnswerEntity
{
    public required Guid Id { get; init; }
    public required string Value { get; set; }
}