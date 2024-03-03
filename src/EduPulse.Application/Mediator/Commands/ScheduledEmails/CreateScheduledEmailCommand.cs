using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Commands.ScheduledEmails;

public record CreateScheduledEmailCommand : CommandBase<ScheduledEmailDto>
{
    public required DateTimeOffset SendsAt { get; init; }
    public required string Recipient { get; init; }
    public required string Subject { get; init; }
    public required string Text { get; init; }
}