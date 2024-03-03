using EduPulse.Application.Abstractions;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Mediator.Commands.Emails;

namespace EduPulse.Application.Mediator.CommandHandlers.Emails;

public class SendEmailCommandHandler : CommandHandlerBase<SendEmailCommand>
{
    private readonly IEmailSender _emailSender;

    public SendEmailCommandHandler(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public override async Task Handle(SendEmailCommand command, CancellationToken cancellationToken)
    {
        await _emailSender.SendEmailAsync(
            "admin@pulse.edu", 
            command.Recipient,
            command.Subject, 
            command.Text, 
            cancellationToken
            );
    }
}