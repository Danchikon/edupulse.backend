using EduPulse.Application.Commands.UserGroups;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Domain.Common.Repositories;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.CommandHandlers.Groups;

public class UpdateGroupCommandHandler : CommandHandlerBase<UpdateGroupCommand, GroupDto>
{
    private readonly IRepository<GroupEntity> _groupsRepository;

    public UpdateGroupCommandHandler(IRepository<GroupEntity> groupsRepository)
    {
        _groupsRepository = groupsRepository;
    }
    
    public override async Task<GroupDto> Handle(UpdateGroupCommand command, CancellationToken cancellationToken)
    {
        var group = new GroupEntity
        {
            Id = command.Id,
            Title = command.Title,
        };

        var groupDto = await _groupsRepository.UpdateAsync<GroupDto>(group, cancellationToken);

        return groupDto;
    }
}