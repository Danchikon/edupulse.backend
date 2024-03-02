namespace EduPulse.Domain.Entities;

public class InstituteEntity
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public required string Code { get; set; }
}