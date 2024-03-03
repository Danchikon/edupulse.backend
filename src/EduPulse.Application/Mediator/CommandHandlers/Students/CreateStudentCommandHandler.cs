using EduPulse.Application.Abstractions;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Users;
using EduPulse.Domain.Common;
using EduPulse.Domain.Common.Enums;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Mediator.CommandHandlers.Students;

public class CreateStudentCommandHandler : CommandHandlerBase<CreateStudentCommand, StudentDto>
{
    private readonly IRepository<StudentEntity> _studentsRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CreateStudentCommandHandler(
        IRepository<StudentEntity> studentsRepository,
        IPasswordHasher passwordHasher
        )
    {
        _studentsRepository = studentsRepository;
        _passwordHasher = passwordHasher;
    }

    public override async Task<StudentDto> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
    {
        var anyStudent = await _studentsRepository.AnyAsync(student => student.Email == command.Email, cancellationToken);

        if (anyStudent)
        {
            throw new BusinessException
            {
                ErrorCode = ErrorCode.StudentWithSameEmailAlreadyExist,
                ErrorKind = ErrorKind.InvalidOperation
            };
        }
        
        var studentId = Guid.NewGuid();
        var createdAt = DateTimeOffset.UtcNow;

        var passwordHash = _passwordHasher.Hash(command.Password);
        
        var studentEntity = new StudentEntity
        {
            Id = studentId,
            Avatar = new Uri($"https://api.dicebear.com/7.x/thumbs/svg?seed={studentId}"),
            GroupId = command.GroupId,
            PhoneNumber = command.PhoneNumber,
            Email = command.Email,
            FullName = command.FullName,
            Age = command.Age,
            PasswordHash = passwordHash,
            CreatedAt = createdAt
        };

        var studentDto = await _studentsRepository.AddAsync<StudentDto>(studentEntity, cancellationToken);

        return studentDto;
    }
}