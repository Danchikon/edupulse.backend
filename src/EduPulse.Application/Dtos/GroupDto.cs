namespace EduPulse.Application.Dtos;

public record GroupDto
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required InstituteDto Institute { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public StudentDto[] Students { get; init; } = Array.Empty<StudentDto>();
}