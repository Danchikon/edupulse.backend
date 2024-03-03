using EduPulse.Domain.Enums;

namespace EduPulse.Domain.Entities;

public class TeacherEntity 
{
    public required Guid Id { get; init; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public Uri? Avatar { get; set; }
    public List<SubjectEntity> Subjects { get; init; } = new();
    public List<GroupEntity> Groups { get; init; } = new();
    public DateTimeOffset CreatedAt { get; init; }
}