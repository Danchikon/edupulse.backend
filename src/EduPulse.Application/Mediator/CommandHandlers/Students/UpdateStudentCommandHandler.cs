using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Users;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Mediator.CommandHandlers.Students;

public class UpdateStudentCommandHandler : CommandHandlerBase<UpdateStudentCommand, StudentDto>
{
    private readonly IRepository<StudentEntity> _studentsRepository;

    public UpdateStudentCommandHandler(IRepository<StudentEntity> studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }

    public override async Task<StudentDto> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
    {
        var studentEntity = await _studentsRepository.SingleAsync(student => student.Id == command.Id, cancellationToken);

        studentEntity.Email = command.Email;
        studentEntity.FullName = command.FullName;
        studentEntity.Age = command.Age;
        studentEntity.PhoneNumber = command.PhoneNumber;
        studentEntity.GroupId = command.GroupId;

        var userDto = await _studentsRepository.UpdateAsync<StudentDto>(studentEntity, cancellationToken);

        return userDto;
    }
}