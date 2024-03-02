namespace EduPulse.Application.Dtos;

public record GroupDto
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public UserDto[] Users { get; init; } = Array.Empty<UserDto>();
}