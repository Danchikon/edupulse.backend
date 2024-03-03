using EduPulse.Application.Abstractions;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Queries.Students;
using EduPulse.Application.Mediator.Queries.Teachers;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;
using MapsterMapper;

namespace EduPulse.Application.Mediator.QueryHandlers.Teachers;

public class CheckTeacherPasswordQueryHandler : QueryHandlerBase<CheckTeacherPasswordQuery, TeacherDto?>
{
    private readonly IRepository<TeacherEntity> _teachersRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    public CheckTeacherPasswordQueryHandler(
        IPasswordHasher passwordHasher, 
        IRepository<TeacherEntity> teachersRepository,
        IMapper mapper
        )
    {
        _passwordHasher = passwordHasher;
        _teachersRepository = teachersRepository;
        _mapper = mapper;
    }


    public override async Task<TeacherDto?> Handle(CheckTeacherPasswordQuery command, CancellationToken cancellationToken)
    {
        var teacherEntity = await _teachersRepository.SingleAsync(teacher => teacher.Email == command.Email, cancellationToken);

        var hash = _passwordHasher.Hash(command.Password);

        return hash == teacherEntity.PasswordHash ? _mapper.Map<TeacherDto>(teacherEntity) : null;
    }
}