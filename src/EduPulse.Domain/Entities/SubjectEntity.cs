namespace EduPulse.Domain.Entities;

public class SubjectEntity
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public GroupEntity[] Groups { get; set; } = Array.Empty<GroupEntity>();
}