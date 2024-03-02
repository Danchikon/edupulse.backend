using MediatR;

namespace EduPulse.Application.Common.Mediator;

public record CommandBase : IRequest;

public record CommandBase<TResponse> : IRequest<TResponse>;