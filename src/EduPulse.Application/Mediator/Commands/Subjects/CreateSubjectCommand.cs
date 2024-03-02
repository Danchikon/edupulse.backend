using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Commands.Subjects;

public record CreateSubjectCommand : CommandBase<SubjectDto>
{
    public required string Title { get; set; }
    public required string Description { get; set; }
}