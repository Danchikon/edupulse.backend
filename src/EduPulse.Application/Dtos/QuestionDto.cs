namespace EduPulse.Application.Dtos;

public record QuestionDto
{
    public required Guid Id { get; init; }
    public required Guid TestId { get; set; }
    public required int Points { get; init; }
    public required string Title { get; init; }
    public AnswerDto[] Answers { get; init; } = Array.Empty<AnswerDto>();
    public required Guid CorrectAnswerId { get; init; }
}