using EduPulse.Application.Abstractions;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Mediator.Commands.Students;
using EduPulse.Application.Mediator.Commands.Users;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Mediator.CommandHandlers.Students;

public class UploadTeacherAvatarCommandHandler: CommandHandlerBase<UploadTeacherAvatarCommand, Uri>
{
    private readonly IRepository<TeacherEntity> _teacherRepository;
    private readonly IFilesStorage _filesStorage;

    public UploadTeacherAvatarCommandHandler(
        IRepository<TeacherEntity> teacherRepository,
        IFilesStorage filesStorage
        )
    {
        _teacherRepository = teacherRepository;
        _filesStorage = filesStorage;
    }

    public override async Task<Uri> Handle(UploadTeacherAvatarCommand command, CancellationToken cancellationToken)
    {
        var teacherEntity = await _teacherRepository.SingleAsync(teacher => teacher.Id == command.TeacherId, cancellationToken);
        
        var fileName = teacherEntity.Id.ToString();

        var avatarUri = _filesStorage.GetUri("avatars", fileName);
        
        teacherEntity.Avatar = avatarUri;
        
        await _teacherRepository.UpdateAsync(teacherEntity, cancellationToken);
        await _filesStorage.UploadAsync(command.Avatar, "avatars", fileName, cancellationToken);

        return avatarUri;
    }
}