using EduPulse.Application.Abstractions;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Users;
using EduPulse.Domain.Common;
using EduPulse.Domain.Common.Enums;
using EduPulse.Domain.Entities;
using MapsterMapper;

namespace EduPulse.Application.Mediator.CommandHandlers.Users;

public class CreateUserCommandHandler : CommandHandlerBase<CreateUserCommand, StudentDto>
{
    private readonly IRepository<StudentEntity> _usersRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUserCommandHandler(
        IRepository<StudentEntity> usersRepository,
        IPasswordHasher passwordHasher
        )
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
    }

    public override async Task<StudentDto> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var anyUser = await _usersRepository.AnyAsync(user => user.Email == command.Email, cancellationToken);

        if (anyUser)
        {
            throw new BusinessException
            {
                ErrorCode = ErrorCode.UserWithSameEmailAlreadyExist,
                ErrorKind = ErrorKind.InvalidOperation
            };
        }
        
        var userId = Guid.NewGuid();
        var createdAt = DateTimeOffset.UtcNow;

        var passwordHash = _passwordHasher.Hash(command.Password);
        
        var userEntity = new StudentEntity
        {
            Id = userId,
            GroupId = command.GroupId,
            PhoneNumber = command.PhoneNumber,
            Email = command.Email,
            FullName = command.FullName,
            Age = command.Age,
            PasswordHash = passwordHash,
            CreatedAt = createdAt
        };

        var userDto = await _usersRepository.AddAsync<StudentDto>(userEntity, cancellationToken);

        return userDto;
    }
}