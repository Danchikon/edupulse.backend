using EduPulse.Application.Common.Mediator;

namespace EduPulse.Application.Mediator.Commands.Emails;

public record SendEmailCommand : CommandBase
{
    public required string Recipient { get; init; }
    public required string Subject { get; init; }
    public required string Text { get; init; }
}