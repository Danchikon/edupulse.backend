using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Domain.Enums;

namespace EduPulse.Application.Mediator.Commands.Users;

public record CreateUserCommand : CommandBase<UserDto>
{
    public required string PhoneNumber { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required int Age { get; set; }
    public required UserRole Role { get; set; }
    public required Guid GroupId { get; set; }
    public required string Password { get; init; }
}