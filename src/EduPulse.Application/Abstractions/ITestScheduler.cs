using EduPulse.Domain.Entities;

namespace EduPulse.Application.Abstractions;

public interface ITestScheduler
{
    Task ScheduleOpenAsync(
        Guid testId,
        DateTimeOffset timestamp, 
        CancellationToken cancellationToken = default
        );
    
    Task ScheduleCloseAsync(
        Guid testId, 
        DateTimeOffset timestamp,
        CancellationToken cancellationToken = default
        );
}