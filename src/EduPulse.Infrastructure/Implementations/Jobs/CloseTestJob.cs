using EduPulse.Application.Mediator.Commands.Tests;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace EduPulse.Infrastructure.Implementations.Jobs;

public class CloseTestJob : IJob
{
    private readonly IMediator _mediator;
    private readonly SemaphoreSlim _semaphore;

    public CloseTestJob(
        IMediator mediator,
        [FromKeyedServices("tests")] SemaphoreSlim semaphore
    )
    {
        _mediator = mediator;
        _semaphore = semaphore;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var lotIdString = context.MergedJobDataMap.GetString("testId")!;

        var command = new CloseTestCommand
        {
            Id = Guid.Parse(lotIdString)
        };
        
        await _semaphore.WaitAsync();

        try
        {
            await _mediator.Send(command, context.CancellationToken);
        }
        finally
        {
            _semaphore.Release();
        }
    }
}