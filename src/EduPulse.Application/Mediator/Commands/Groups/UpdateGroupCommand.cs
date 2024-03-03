using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Commands.Groups;

public record UpdateGroupCommand : CommandBase<GroupDto>
{
    public required Guid Id { get; init; }
    public required Guid InstituteId { get; init; }
    public required string Title { get; init; }
}