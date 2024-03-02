using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Mediator.Commands.Groups;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Mediator.CommandHandlers.Groups;

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