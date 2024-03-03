namespace EduPulse.Application.Dtos;

public record ScheduledEmailDto
{
    public required Guid Id { get; init; }
    public required DateTimeOffset SendsAt { get; init; }
    public required string Recipient { get; init; }
    public required string Subject { get; init; }
    public required string Text { get; init; }
}