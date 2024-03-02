using EduPulse.Application.Abstractions;
using EduPulse.Application.Commands.Users;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Domain.Common.Errors;
using EduPulse.Domain.Common.Exceptions;
using EduPulse.Domain.Common.Repositories;
using EduPulse.Domain.Entities;
using MapsterMapper;

namespace EduPulse.Application.CommandHandlers.Users;

public class CreateUserCommandHandler : CommandHandlerBase<CreateUserCommand, UserDto>
{
    private readonly IRepository<UserEntity> _usersRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUserCommandHandler(
        IRepository<UserEntity> usersRepository,
        IPasswordHasher passwordHasher, 
        IMapper mapper
        )
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public override async Task<UserDto> Handle(CreateUserCommand command, CancellationToken cancellationToken)
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
        
        var userEntity = new UserEntity
        {
            Id = userId,
            GroupId = command.GroupId,
            PhoneNumber = command.PhoneNumber,
            Email = command.Email,
            FullName = command.FullName,
            Age = command.Age,
            Role = command.Role,
            PasswordHash = passwordHash,
            CreatedAt = createdAt
        };

        var userDto = await _usersRepository.AddAsync<UserDto>(userEntity, cancellationToken);

        return userDto;
    }
}