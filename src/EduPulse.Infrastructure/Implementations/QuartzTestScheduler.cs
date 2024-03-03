using EduPulse.Application.Abstractions;
using EduPulse.Domain.Entities;
using EduPulse.Infrastructure.Implementations.Jobs;
using Quartz;

namespace EduPulse.Infrastructure.Implementations;

public class QuartzTestScheduler : ITestScheduler
{
    private readonly ISchedulerFactory _schedulerFactory;

    public QuartzTestScheduler(ISchedulerFactory schedulerFactory)
    {
        _schedulerFactory = schedulerFactory;
    }

    public async Task ScheduleOpenAsync(
        Guid testId,
        DateTimeOffset timestamp, 
        CancellationToken cancellationToken = default
    )
    {
        var scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
        
        var jobDetail = JobBuilder
            .Create<OpenTestJob>()
            .WithIdentity(Guid.NewGuid().ToString())
            .SetJobData(new JobDataMap
            {
                ["testId"] = testId.ToString(),
            })
            .Build();

        var trigger = TriggerBuilder
            .Create()
            .StartAt(timestamp)
            .Build();
        
        await scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
    }
    
    public async Task ScheduleCloseAsync(
        Guid testId,
        DateTimeOffset timestamp, 
        CancellationToken cancellationToken = default
    )
    {
        var scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
        
        var jobDetail = JobBuilder
            .Create<CloseTestJob>()
            .WithIdentity(Guid.NewGuid().ToString())
            .SetJobData(new JobDataMap
            {
                ["testId"] = testId.ToString(),
            })
            .Build();

        var trigger = TriggerBuilder
            .Create()
            .StartAt(timestamp)
            .Build();
        
        await scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
    }
}