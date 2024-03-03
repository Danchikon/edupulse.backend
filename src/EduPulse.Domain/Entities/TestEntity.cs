using EduPulse.Domain.Enums;

namespace EduPulse.Domain.Entities;

public class TestEntity
{
    public required Guid Id { get; init; }
    public required Guid GroupId { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    
    public GroupEntity? Group { get; set; }
    public required TestStatus Status { get; set; } = TestStatus.Scheduled;
    public required DateTimeOffset OpensAt { get; set; }
    public required DateTimeOffset ClosesAt { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public List<QuestionEntity> Questions { get; set; } = new();
}