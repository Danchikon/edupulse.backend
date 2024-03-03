namespace EduPulse.Application.Dtos;

public record TestClosedEventDto
{
    public required Guid TestId { get; init; }
}