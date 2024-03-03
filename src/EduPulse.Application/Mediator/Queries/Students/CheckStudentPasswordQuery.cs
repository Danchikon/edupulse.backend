using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;

namespace EduPulse.Application.Mediator.Queries.Students;

public record CheckStudentPasswordQuery : QueryBase<StudentDto?>
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}