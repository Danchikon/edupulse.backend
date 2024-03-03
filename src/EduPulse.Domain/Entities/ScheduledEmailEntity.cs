namespace EduPulse.Domain.Entities;

public class ScheduledEmailEntity
{
    public required Guid Id { get; init; }
    public required DateTimeOffset SendsAt { get; set; }
    public required string Recipient { get; set; }
    public required string Subject { get; set; }
    public required string Text { get; set; }
}