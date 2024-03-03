namespace EduPulse.Application.Dtos;

public record TestClosedEventDto
{
    public required Guid GroupId { get; init; }
    public required Guid TestId { get; init; }
}