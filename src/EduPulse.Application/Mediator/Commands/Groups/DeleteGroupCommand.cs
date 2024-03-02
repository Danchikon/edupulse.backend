using EduPulse.Application.Common.Mediator;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Commands.UserGroups;

public record DeleteGroupCommand : CommandBase
{
    public required Guid Id { get; init; }
}