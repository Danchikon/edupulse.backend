using EduPulse.Domain.Enums;

namespace EduPulse.Domain.Entities;

public class StudentEntity 
{
    public required Guid Id { get; init; }
    public required string PhoneNumber { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required int Age { get; set; }
    public required string PasswordHash { get; set; }
    public Uri? Avatar { get; set; }
    public GroupEntity? Group { get; set; }
    public required Guid GroupId { get; set; }
    public DateTimeOffset CreatedAt { get; init; }
}