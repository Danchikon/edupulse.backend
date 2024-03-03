namespace EduPulse.Infrastructure.Options;

public record SmtpOptions
{
    public const string Section = "Smtp";
    
    public required string Host { get; init; }
    public required int Port { get; init; }
}