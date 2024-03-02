using EduPulse.Application.Abstractions;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Queries.Users;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;
using MapsterMapper;

namespace EduPulse.Application.Mediator.QueryHandlers.Users;

public class CheckUserPasswordQueryHandler : QueryHandlerBase<CheckUserPasswordQuery, StudentDto?>
{
    private readonly IRepository<StudentEntity> _usersRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    public CheckUserPasswordQueryHandler(
        IPasswordHasher passwordHasher, 
        IRepository<StudentEntity> usersRepository,
        IMapper mapper
        )
    {
        _passwordHasher = passwordHasher;
        _usersRepository = usersRepository;
        _mapper = mapper;
    }


    public override async Task<StudentDto?> Handle(CheckUserPasswordQuery command, CancellationToken cancellationToken)
    {
        var userEntity = await _usersRepository.SingleAsync(user => user.Email == command.Email, cancellationToken);

        var hash = _passwordHasher.Hash(command.Password);

        return hash == userEntity.PasswordHash ? _mapper.Map<StudentDto>(userEntity) : null;
    }
}