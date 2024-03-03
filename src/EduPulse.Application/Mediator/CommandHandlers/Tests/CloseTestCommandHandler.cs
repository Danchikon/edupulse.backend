using EduPulse.Application.Abstractions;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Tests;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;
using EduPulse.Domain.Enums;

namespace EduPulse.Application.Mediator.CommandHandlers.Tests;

public class CloseTestCommandHandler : CommandHandlerBase<CloseTestCommand, TestDto>
{
    private readonly IRepository<TestEntity> _testsRepository;
    private readonly IEventsPublisher _eventsPublisher;

    public CloseTestCommandHandler(
        IRepository<TestEntity> testsRepository,
        IEventsPublisher eventsPublisher
        )
    {
        _testsRepository = testsRepository;
        _eventsPublisher = eventsPublisher;
    }

    public override async Task<TestDto> Handle(CloseTestCommand command, CancellationToken cancellationToken)
    {
        var testEntity = await _testsRepository.SingleAsync(test => test.Id == command.Id, cancellationToken);

        testEntity.Status = TestStatus.Closed;

        var testDto = await _testsRepository.UpdateAsync<TestDto>(testEntity, cancellationToken);

        await _eventsPublisher.PublishAsync(new EventDto<TestClosedEventDto>
        {
            Channel = "tests.closed",
            Data = new TestClosedEventDto
            {
                TestId = testEntity.Id
            }
        }, cancellationToken);
        
        return testDto;
    }
}