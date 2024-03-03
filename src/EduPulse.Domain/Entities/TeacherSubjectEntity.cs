namespace EduPulse.Domain.Entities;

public class TeacherSubjectEntity
{
    public required Guid SubjectId { get; set; }
    public SubjectEntity? Subject { get; set; }
    public required Guid TeacherId { get; set; }
    public TeacherEntity? Teacher { get; set; }
}