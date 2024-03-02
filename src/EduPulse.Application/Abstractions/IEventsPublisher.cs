using EduPulse.Application.Dtos;

namespace EduPulse.Application.Abstractions;

public interface IEventsPublisher
{
    Task PublishAsync<TData>(EventDto<TData> @event, CancellationToken cancellationToken = default);
}