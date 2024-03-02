using EduPulse.Domain.Common;
using MediatR;

namespace EduPulse.Application.Common.Mediator;

public class TransactionalPipelineBehaviour<TRequest, TResponse>(IUnitOfWork unitOfWork)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseRequest
{
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken = default
    )
    {
        await unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            var result = await next.Invoke();

            await unitOfWork.CommitTransactionAsync(cancellationToken);
            
            return result;
        }
        catch
        {
            await unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }
}