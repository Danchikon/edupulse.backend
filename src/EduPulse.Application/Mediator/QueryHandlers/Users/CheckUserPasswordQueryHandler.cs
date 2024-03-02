using EduPulse.Application.Abstractions;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Queries.Users;
using EduPulse.Domain.Common.Repositories;
using EduPulse.Domain.Entities;
using MapsterMapper;

namespace EduPulse.Application.Mediator.QueryHandlers.Users;

public class CheckUserPasswordQueryHandler : QueryHandlerBase<CheckUserPasswordQuery, UserDto?>
{
    private readonly IRepository<UserEntity> _usersRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    public CheckUserPasswordQueryHandler(
        IPasswordHasher passwordHasher, 
        IRepository<UserEntity> usersRepository,
        IMapper mapper
        )
    {
        _passwordHasher = passwordHasher;
        _usersRepository = usersRepository;
        _mapper = mapper;
    }


    public override async Task<UserDto?> Handle(CheckUserPasswordQuery command, CancellationToken cancellationToken)
    {
        var userEntity = await _usersRepository.SingleAsync(user => user.Email == command.Email, cancellationToken);

        var hash = _passwordHasher.Hash(command.Password);

        return hash == userEntity.PasswordHash ? _mapper.Map<UserDto>(userEntity) : null;
    }
}