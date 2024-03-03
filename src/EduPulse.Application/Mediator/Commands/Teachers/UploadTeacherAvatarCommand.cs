using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Commands.Users;

public record UploadTeacherAvatarCommand : CommandBase<Uri>
{
    public required Guid TeacherId { get; init; }
    public required FileDto Avatar { get; init; }
}