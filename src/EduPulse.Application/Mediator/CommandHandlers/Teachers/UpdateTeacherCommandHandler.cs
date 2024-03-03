using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Users;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Mediator.CommandHandlers.Students;

public class UpdateTeacherCommandHandler : CommandHandlerBase<UpdateTeacherCommand, TeacherDto>
{
    private readonly IRepository<StudentEntity> _teachersRepository;

    public UpdateTeacherCommandHandler(IRepository<StudentEntity> teachersRepository)
    {
        _teachersRepository = teachersRepository;
    }

    public override async Task<TeacherDto> Handle(UpdateTeacherCommand command, CancellationToken cancellationToken)
    {
        var teacherEntity = await _teachersRepository.SingleAsync(teacher => teacher.Id == command.Id, cancellationToken);

        teacherEntity.Email = command.Email;
        teacherEntity.FullName = command.FullName;

        var teacherDto = await _teachersRepository.UpdateAsync<TeacherDto>( teacherEntity, cancellationToken);

        return teacherDto;
    }
}