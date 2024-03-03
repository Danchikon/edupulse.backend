namespace EduPulse.Application.Dtos;

public record GroupDto
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required Guid GroupId { get; init; }
    public required InstituteDto Institute { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public TeacherDto[] Teachers { get; init; } = Array.Empty<TeacherDto>();
    public StudentDto[] Students { get; init; } = Array.Empty<StudentDto>();
}