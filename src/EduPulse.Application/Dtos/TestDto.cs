using EduPulse.Domain.Enums;

namespace EduPulse.Application.Dtos;

public record TestDto
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required DateTimeOffset StartsAt { get; init; }
    public required DateTimeOffset EndsAt { get; init; }
    public required TestStatus Status { get; init; }
    public QuestionDto[] Questions { get; init; } = Array.Empty<QuestionDto>();
    public required DateTimeOffset CreatedAt { get; init; }
}