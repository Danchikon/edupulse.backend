using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Commands.Tests;

public record CreateAnswerCommand : CommandBase<AnswerDto>
{
    public required string Value { get; init; }
}