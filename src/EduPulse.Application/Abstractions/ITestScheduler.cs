using EduPulse.Domain.Entities;

namespace EduPulse.Application.Abstractions;

public interface ITestScheduler
{
    Task ScheduleAsync(TestEntity test, CancellationToken cancellationToken = default);
}