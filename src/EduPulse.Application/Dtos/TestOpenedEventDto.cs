namespace EduPulse.Application.Dtos;

public record TestOpenedEventDto
{
    public required Guid GroupId { get; init; }
    public required Guid TestId { get; init; }
}