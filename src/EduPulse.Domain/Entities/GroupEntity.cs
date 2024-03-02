namespace EduPulse.Domain.Entities;

public class GroupEntity
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public Guid InstituteId { get; set; }
    public InstituteEntity? Institute { get; set; }
    
    public TeacherEntity[] Teachers { get; init; } = Array.Empty<TeacherEntity>();
    public StudentEntity[] Students { get; init; } = Array.Empty<StudentEntity>();
    public SubjectEntity[] Subjects { get; init; } = Array.Empty<SubjectEntity>();
    public DateTimeOffset CreatedAt { get; set; }
}