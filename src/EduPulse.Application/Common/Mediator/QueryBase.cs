using MediatR;

namespace EduPulse.Application.Common.Mediator;

public record QueryBase<TResponse> : IRequest<TResponse>;