using System.Net.Mail;
using EduPulse.Application.Abstractions;

namespace EduPulse.Infrastructure.Implementations;

public class SmtpEmailSender : IEmailSender
{
    private readonly SmtpClient _smtpClient;

    public SmtpEmailSender(SmtpClient smtpClient)
    {
        _smtpClient = smtpClient;
    }

    public async Task SendEmailAsync(
        string from, 
        string to, 
        string subject,
        string body,
        CancellationToken cancellationToken
        )
    {
        await _smtpClient.SendMailAsync(new MailMessage(from, to, subject, body), cancellationToken);
    }
}