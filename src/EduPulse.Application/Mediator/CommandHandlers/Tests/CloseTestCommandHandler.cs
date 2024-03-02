using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Mediator.Commands.Tests;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;
using EduPulse.Domain.Enums;

namespace EduPulse.Application.Mediator.CommandHandlers.Tests;

public class CloseTestCommandHandler : CommandHandlerBase<CloseTestCommand>
{
    private readonly IRepository<TestEntity> _testsRepository;

    public CloseTestCommandHandler(IRepository<TestEntity> testsRepository)
    {
        _testsRepository = testsRepository;
    }

    public override async Task Handle(CloseTestCommand command, CancellationToken cancellationToken)
    {
        var testEntity = await _testsRepository.SingleAsync(test => test.Id == command.Id, cancellationToken);

        testEntity.Status = TestStatus.Closed;

        await _testsRepository.UpdateAsync(testEntity, cancellationToken);
    }
}