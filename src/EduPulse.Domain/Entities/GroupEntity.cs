namespace EduPulse.Domain.Entities;

public class GroupEntity
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public UserEntity[] Users { get; init; } = Array.Empty<UserEntity>();
    public SubjectEntity[] Subjects { get; init; } = Array.Empty<SubjectEntity>();
    public DateTimeOffset CreatedAt { get; set; }
}