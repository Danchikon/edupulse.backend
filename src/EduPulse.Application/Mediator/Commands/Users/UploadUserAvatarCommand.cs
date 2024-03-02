using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Commands.Users;

public record UploadUserAvatarCommand : CommandBase<Uri>
{
    public required Guid UserId { get; init; }
    public required FileDto Avatar { get; init; }
}