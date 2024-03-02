namespace EduPulse.Domain.Entities;

public class SubjectEntity
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public List<GroupEntity> Groups { get; set; } = new();
    public List<StudentEntity> Teachers { get; set; } = new();
    public required DateTimeOffset CreatedAt { get; init; }
}