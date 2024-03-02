namespace EduPulse.Infrastructure.Options;

public record JsonWebTokenOptions
{
    public const string Section = "JsonWebToken";
    
    public required string JsonWebKey { get; init; }
}