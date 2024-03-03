using EduPulse.Application.Mediator.Commands.Emails;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;
using MediatR;
using Quartz;

namespace EduPulse.Infrastructure.Implementations.Jobs;

public class SendScheduledEmailJob : IJob
{
    private readonly IMediator _mediator;
    private readonly IRepository<ScheduledEmailEntity> _scheduledEmailsRepository;

    public SendScheduledEmailJob(
        IMediator mediator, 
        IRepository<ScheduledEmailEntity> scheduledEmailsRepository
        )
    {
        _mediator = mediator;
        _scheduledEmailsRepository = scheduledEmailsRepository;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var scheduledEmailIdString = context.MergedJobDataMap.GetString("scheduledEmailId")!;
        var scheduledEmailId = Guid.Parse(scheduledEmailIdString);
        
        var scheduledEmailEntity = await _scheduledEmailsRepository.SingleAsync(email => email.Id == scheduledEmailId, context.CancellationToken);

        await _mediator.Send(new SendEmailCommand
        {
            Recipient = scheduledEmailEntity.Recipient,
            Subject = scheduledEmailEntity.Subject,
            Text = scheduledEmailEntity.Text
        }, context.CancellationToken);
    }
}