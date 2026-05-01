using MediatR;

namespace InstaConnect.Common.Application.Features.Messaging.Abstractions;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
	where TCommand : ICommandRequest;

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
	where TCommand : ICommandRequest<TResponse>;
