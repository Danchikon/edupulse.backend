using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Mediator.Commands.Teachers;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Mediator.CommandHandlers.Students;

public class AddTeacherToGroupCommandHandler : CommandHandlerBase<AddTeacherToGroupCommand>
{
    private readonly IRepository<TeacherGroupEntity> _teacherGroupsRepository;

    public AddTeacherToGroupCommandHandler(IRepository<TeacherGroupEntity> teacherGroupsRepository)
    {
        _teacherGroupsRepository = teacherGroupsRepository;
    }

    public override async Task Handle(AddTeacherToGroupCommand command, CancellationToken cancellationToken)
    {
        await _teacherGroupsRepository.AddAsync(new TeacherGroupEntity
        {
            GroupId = command.GroupId,
            TeacherId = command.TeacherId
        }, cancellationToken);
    }
}