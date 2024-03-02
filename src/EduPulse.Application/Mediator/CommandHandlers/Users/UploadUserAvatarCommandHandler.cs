using EduPulse.Application.Abstractions;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Mediator.Commands.Users;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Mediator.CommandHandlers.Users;

public class UploadUserAvatarCommandHandler: CommandHandlerBase<UploadUserAvatarCommand, Uri>
{
    private readonly IRepository<StudentEntity> _usersRepository;
    private readonly IFilesStorage _filesStorage;

    public UploadUserAvatarCommandHandler(
        IRepository<StudentEntity> usersRepository,
        IFilesStorage filesStorage
        )
    {
        _usersRepository = usersRepository;
        _filesStorage = filesStorage;
    }

    public override async Task<Uri> Handle(UploadUserAvatarCommand command, CancellationToken cancellationToken)
    {
        var userEntity = await _usersRepository.SingleAsync(user => user.Id == command.UserId, cancellationToken);
        
        var fileName = userEntity.Id.ToString();

        var avatarUri = _filesStorage.GetUri("avatars", fileName);
        
        userEntity.Avatar = avatarUri;
        
        await _usersRepository.UpdateAsync(userEntity, cancellationToken);
        await _filesStorage.UploadAsync(command.Avatar, "avatars", fileName, cancellationToken);

        return avatarUri;
    }
}