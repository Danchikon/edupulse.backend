namespace EduPulse.Application.Abstractions;

public interface IEmailScheduler
{
    Task ScheduleAsync(
        Guid emailId,
        DateTimeOffset timestamp, 
        CancellationToken cancellationToken = default
    );
}