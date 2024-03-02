using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Commands.Groups;

public record CreateGroupCommand : CommandBase<GroupDto>
{
    public required string Title { get; init; }
}