namespace EduPulse.Application.Abstractions;

public interface IEmailSender
{
    Task SendEmailAsync(
        string from,
        string to,
        string subject,
        string body,
        CancellationToken cancellationToken
    );
}