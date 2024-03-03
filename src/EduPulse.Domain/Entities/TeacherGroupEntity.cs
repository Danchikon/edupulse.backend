namespace EduPulse.Domain.Entities;

public class TeacherGroupEntity
{
    public required Guid GroupId { get; set; }
    public GroupEntity? Group { get; set; }
    public required Guid TeacherId { get; set; }
    public TeacherEntity? Teacher { get; set; }
}