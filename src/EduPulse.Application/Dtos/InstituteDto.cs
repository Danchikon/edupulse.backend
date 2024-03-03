namespace EduPulse.Application.Dtos;

public record InstituteDto
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Code { get; init; }
}