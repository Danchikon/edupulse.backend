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

    public async Task ScheduleAsync(TestEntity test, CancellationToken cancellationToken = default)
    {
        var scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
        
        var openJobDetail = JobBuilder
            .Create<OpenTestJob>()
            .SetJobData(new JobDataMap
            {
                ["testId"] = test.Id.ToString(),
            })
            .Build();

        var openTrigger = TriggerBuilder
            .Create()
            .StartAt(test.OpensAt)
            .Build();
        
        var closeJobDetail = JobBuilder
            .Create<CloseTestJob>()
            .SetJobData(new JobDataMap
            {
                ["testId"] = test.Id.ToString(),
            })
            .Build();

        var closeTrigger = TriggerBuilder
            .Create()
            .StartAt(test.ClosesAt)
            .Build();
        

        await scheduler.ScheduleJob(openJobDetail, openTrigger, cancellationToken);
        await scheduler.ScheduleJob(closeJobDetail, closeTrigger, cancellationToken);
    }
}