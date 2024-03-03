namespace EduPulse.Application.Dtos;

public record TestOpenedEventDto
{
    public required Guid TestId { get; init; }
}