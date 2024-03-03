using EduPulse.Domain.Entities;
using EduPulse.Domain.Enums;

namespace EduPulse.Application.Dtos;

public record StudentDto
{
    public required Guid Id { get; init; }
    public required Guid GroupId { get; init; }
    public required GroupEntity Group { get; init; }
    public required string PhoneNumber { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required int Age { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
}