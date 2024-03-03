using EduPulse.Application.Abstractions;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.ScheduledEmails;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Mediator.CommandHandlers.ScheduledEmails;

public class CreateScheduledEmailCommandHandler : CommandHandlerBase<CreateScheduledEmailCommand, ScheduledEmailDto>
{
    private readonly IRepository<ScheduledEmailEntity> _scheduledEmailsRepository;
    private readonly IEmailScheduler _emailScheduler;

    public CreateScheduledEmailCommandHandler(
        IRepository<ScheduledEmailEntity> scheduledEmailsRepository,
        IEmailScheduler emailScheduler
        )
    {
        _scheduledEmailsRepository = scheduledEmailsRepository;
        _emailScheduler = emailScheduler;
    }

    public override async Task<ScheduledEmailDto> Handle(CreateScheduledEmailCommand command, CancellationToken cancellationToken)
    {
        var scheduledEmailEntity = new ScheduledEmailEntity
        {
            Id = Guid.NewGuid(),
            Recipient = command.Recipient,
            SendsAt = command.SendsAt,
            Subject = command.Subject,
            Text = command.Text
        };

        var scheduledEmailDto = await _scheduledEmailsRepository.AddAsync<ScheduledEmailDto>(scheduledEmailEntity, cancellationToken);

        await _emailScheduler.ScheduleAsync(
            scheduledEmailEntity.Id, 
            scheduledEmailEntity.SendsAt,
            cancellationToken
            );
        
        return scheduledEmailDto;
    }
}