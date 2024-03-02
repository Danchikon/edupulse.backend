namespace EduPulse.Application.Dtos;

public record QuestionDto
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public AnswerDto[] Answers { get; init; } = Array.Empty<AnswerDto>();
    public required Guid CorrectAnswerId { get; init; }
}