using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Commands.Students;

public record UploadStudentAvatarCommand : CommandBase<Uri>
{
    public required Guid StudentId { get; init; }
    public required FileDto Avatar { get; init; }
}