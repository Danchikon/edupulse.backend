using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Queries.Teachers;

public record CheckTeacherPasswordQuery : QueryBase<TeacherDto?>
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}