using EduPulse.Application.Commands.UserGroups;
using EduPulse.Application.Common.Mediator;
using EduPulse.Domain.Common.Repositories;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.CommandHandlers.Groups;

public class DeleteGroupCommandHandler : CommandHandlerBase<DeleteGroupCommand>
{
    private readonly IRepository<GroupEntity> _groupsRepository;

    public DeleteGroupCommandHandler(IRepository<GroupEntity> groupsRepository)
    {
        _groupsRepository = groupsRepository;
    }
    
    public override async Task Handle(DeleteGroupCommand command, CancellationToken cancellationToken)
    {
        await _groupsRepository.RemoveAsync(group => group.Id == command.Id, cancellationToken);
    }
}