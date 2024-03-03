using EduPulse.Application.Abstractions;
using EduPulse.Infrastructure.Implementations.Jobs;
using Quartz;

namespace EduPulse.Infrastructure.Implementations;

public class QuartzEmailScheduler : IEmailScheduler
{
    private readonly ISchedulerFactory _schedulerFactory;

    public QuartzEmailScheduler(ISchedulerFactory schedulerFactory)
    {
        _schedulerFactory = schedulerFactory;
    }

    public async Task ScheduleAsync(
        Guid emailId,
        DateTimeOffset timestamp, 
        CancellationToken cancellationToken = default
        )
    {
        var jobDetail = JobBuilder
            .Create<SendScheduledEmailJob>()
            .SetJobData(new JobDataMap
            {
                ["scheduledEmailId"] = emailId.ToString(),
            })
            .Build();

        var trigger = TriggerBuilder
            .Create()
            .StartAt(timestamp)
            .Build();
        
        var scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
        
        await scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
    }
}