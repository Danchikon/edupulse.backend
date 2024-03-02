using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Commands.UserGroups;

public record UpdateGroupCommand : CommandBase<GroupDto>
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
}