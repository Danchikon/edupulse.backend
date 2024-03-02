using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Commands.Groups;

public record CreateGroupCommand : CommandBase<GroupDto>
{
    public required string Title { get; set; }
}