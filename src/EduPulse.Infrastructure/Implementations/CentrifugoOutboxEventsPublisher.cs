using System.Text.Json;
using System.Text.Json.Nodes;
using EduPulse.Application.Abstractions;
using EduPulse.Application.Dtos;
using EduPulse.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduPulse.Infrastructure.Implementations;

public class CentrifugoOutboxEventsPublisher<TDbContext>(TDbContext dbContext) : IEventsPublisher where TDbContext: DbContext
{
    public async Task PublishAsync<TData>(EventDto<TData> @event, CancellationToken cancellationToken = default)
    {
        var data = JsonSerializer.SerializeToNode(@event.Data);
        
        var payload = new JsonObject
        {
            ["channel"] = @event.Channel,
            ["data"] = data
        };
        
        var outboxEntity = new CentrifugoOutboxEntity
        {
            Id = 0,
            Partition = 0,
            Method = "publish",
            Payload = payload.ToJsonString(),
            CreatedAt = DateTimeOffset.UtcNow
        };

        await dbContext
            .Set<CentrifugoOutboxEntity>()
            .AddAsync(outboxEntity, cancellationToken);
        
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}