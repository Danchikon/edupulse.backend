using EduPulse.Application.Abstractions;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Queries.Students;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;
using MapsterMapper;

namespace EduPulse.Application.Mediator.QueryHandlers.Students;

public class CheckStudentPasswordQueryHandler : QueryHandlerBase<CheckStudentPasswordQuery, StudentDto?>
{
    private readonly IRepository<StudentEntity> _studentsRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    public CheckStudentPasswordQueryHandler(
        IPasswordHasher passwordHasher, 
        IRepository<StudentEntity> studentsRepository,
        IMapper mapper
        )
    {
        _passwordHasher = passwordHasher;
        _studentsRepository = studentsRepository;
        _mapper = mapper;
    }


    public override async Task<StudentDto?> Handle(CheckStudentPasswordQuery command, CancellationToken cancellationToken)
    {
        var studentEntity = await _studentsRepository.SingleAsync(student => student.Email == command.Email, cancellationToken);

        var hash = _passwordHasher.Hash(command.Password);

        return hash == studentEntity.PasswordHash ? _mapper.Map<StudentDto>(studentEntity) : null;
    }
}