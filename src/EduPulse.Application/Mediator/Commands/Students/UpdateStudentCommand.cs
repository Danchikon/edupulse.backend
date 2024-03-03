using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Domain.Enums;

namespace EduPulse.Application.Mediator.Commands.Users;

public record UpdateStudentCommand : CommandBase<StudentDto>
{
    public required Guid Id { get; init; }
    public required string PhoneNumber { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required int Age { get; init; }
    public required Guid GroupId { get; init; }
    public required string Password { get; init; }
}