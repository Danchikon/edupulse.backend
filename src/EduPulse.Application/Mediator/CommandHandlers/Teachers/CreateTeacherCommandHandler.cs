using EduPulse.Application.Abstractions;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Teachers;
using EduPulse.Application.Mediator.Commands.Users;
using EduPulse.Domain.Common;
using EduPulse.Domain.Common.Enums;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Mediator.CommandHandlers.Students;

public class CreateTeacherCommandHandler : CommandHandlerBase<CreateTeacherCommand, TeacherDto>
{
    private readonly IRepository<TeacherEntity> _teachersRepository;
    private readonly IRepository<TeacherGroupEntity> _teacherGroupsRepository;
    private readonly IRepository<TeacherSubjectEntity> _teacherSubjectsRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CreateTeacherCommandHandler(
        IRepository<TeacherEntity> teachersRepository,
        IPasswordHasher passwordHasher, 
        IRepository<TeacherGroupEntity> teacherGroupsRepository,
        IRepository<TeacherSubjectEntity> teacherSubjectsRepository
        )
    {
        _teachersRepository = teachersRepository;
        _passwordHasher = passwordHasher;
        _teacherGroupsRepository = teacherGroupsRepository;
        _teacherSubjectsRepository = teacherSubjectsRepository;
    }

    public override async Task<TeacherDto> Handle(CreateTeacherCommand command, CancellationToken cancellationToken)
    {
        var anyTeacher = await _teachersRepository.AnyAsync(teacher => teacher.Email == command.Email, cancellationToken);

        if (anyTeacher)
        {
            throw new BusinessException
            {
                ErrorCode = ErrorCode.TeacherWithSameEmailAlreadyExist,
                ErrorKind = ErrorKind.InvalidOperation
            };
        }
        
        var teacherId = Guid.NewGuid();
        var createdAt = DateTimeOffset.UtcNow;

        var passwordHash = _passwordHasher.Hash(command.Password);
        
        var studentEntity = new TeacherEntity
        {
            Id = teacherId,
            Email = command.Email,
            FullName = command.FullName,
            PasswordHash = passwordHash,
            CreatedAt = createdAt
        };

        var teacherDto = await _teachersRepository.AddAsync<TeacherDto>(studentEntity, cancellationToken);

        return teacherDto;
    }
}