using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Groups;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Mediator.CommandHandlers.Groups;

public class CreateGroupCommandHandler: CommandHandlerBase<CreateGroupCommand, GroupDto>
{
    private readonly IRepository<GroupEntity> _groupsRepository;

    public CreateGroupCommandHandler(IRepository<GroupEntity> groupsRepository)
    {
        _groupsRepository = groupsRepository;
    }

    public override async Task<GroupDto> Handle(CreateGroupCommand command, CancellationToken cancellationToken)
    {
        var groupId = Guid.NewGuid();
        var createdAt = DateTimeOffset.UtcNow;
        
        var group = new GroupEntity
        {
            Id = groupId,
            Title = command.Title,
            InstituteId = command.InstituteId,
            CreatedAt = createdAt
        };

        var groupDto = await _groupsRepository.AddAsync<GroupDto>(group, cancellationToken);

        return groupDto;
    }
}