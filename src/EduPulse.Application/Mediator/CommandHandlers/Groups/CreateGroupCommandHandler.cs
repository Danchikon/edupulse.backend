using EduPulse.Application.Commands.Groups;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Domain.Common.Repositories;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.CommandHandlers.Groups;

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
            CreatedAt = createdAt
        };

        var groupDto = await _groupsRepository.AddAsync<GroupDto>(group, cancellationToken);

        return groupDto;
    }
}