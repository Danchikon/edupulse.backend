using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Mediator.Commands.Teachers;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Mediator.CommandHandlers.Students;

public class AddTeacherToSubjectCommandHandler : CommandHandlerBase<AddTeacherToSubjectCommand>
{
    private readonly IRepository<TeacherSubjectEntity> _teacherSubjectsRepository;

    public AddTeacherToSubjectCommandHandler(IRepository<TeacherSubjectEntity> teacherSubjectsRepository)
    {
        _teacherSubjectsRepository = teacherSubjectsRepository;
    }

    public override async Task Handle(AddTeacherToSubjectCommand command, CancellationToken cancellationToken)
    {
        await _teacherSubjectsRepository.AddAsync(new TeacherSubjectEntity
        {
            SubjectId = command.SubjectId,
            TeacherId = command.TeacherId
        }, cancellationToken);
    }
}