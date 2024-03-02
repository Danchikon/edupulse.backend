namespace EduPulse.Application.Dtos;

public record SubjectDto
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
}