using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Subjects;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Mediator.CommandHandlers.Subjects;

public class CreateSubjectCommandHandler : CommandHandlerBase<CreateSubjectCommand, SubjectDto>
{
    private readonly IRepository<SubjectEntity> _subjectsRepository;

    public CreateSubjectCommandHandler(IRepository<SubjectEntity> subjectsRepository)
    {
        _subjectsRepository = subjectsRepository;
    }

    public override async Task<SubjectDto> Handle(CreateSubjectCommand command, CancellationToken cancellationToken)
    {
        var subjectId = Guid.NewGuid();
        var createdAt = DateTimeOffset.UtcNow;

        var subjectEntity = new SubjectEntity
        {
            Id = subjectId,
            Title = command.Title,
            Description = command.Description,
            CreatedAt = createdAt
        };

        var subjectDto = await _subjectsRepository.AddAsync<SubjectDto>(subjectEntity, cancellationToken);

        return subjectDto;
    }
}