using MediatR;

namespace EduPulse.Application.Common.Mediator;

public record StreamQueryBase<TResponse> : IStreamRequest<TResponse>;