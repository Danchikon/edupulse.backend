namespace EduPulse.Application.Dtos;

public record AnswerDto
{
    public required Guid Id { get; init; }
    public required string Value { get; init; }
}