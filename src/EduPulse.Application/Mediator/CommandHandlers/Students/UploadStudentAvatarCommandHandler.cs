using EduPulse.Application.Abstractions;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Mediator.Commands.Students;
using EduPulse.Application.Mediator.Commands.Users;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Mediator.CommandHandlers.Students;

public class UploadStudentAvatarCommandHandler: CommandHandlerBase<UploadStudentAvatarCommand, Uri>
{
    private readonly IRepository<StudentEntity> _studentsRepository;
    private readonly IFilesStorage _filesStorage;

    public UploadStudentAvatarCommandHandler(
        IRepository<StudentEntity> studentsRepository,
        IFilesStorage filesStorage
        )
    {
        _studentsRepository = studentsRepository;
        _filesStorage = filesStorage;
    }

    public override async Task<Uri> Handle(UploadStudentAvatarCommand command, CancellationToken cancellationToken)
    {
        var studentEntity = await _studentsRepository.SingleAsync(student => student.Id == command.StudentId, cancellationToken);
        
        var fileName = studentEntity.Id.ToString();

        var avatarUri = _filesStorage.GetUri("avatars", fileName);
        
        studentEntity.Avatar = avatarUri;
        
        await _studentsRepository.UpdateAsync(studentEntity, cancellationToken);
        await _filesStorage.UploadAsync(command.Avatar, "avatars", fileName, cancellationToken);

        return avatarUri;
    }
}