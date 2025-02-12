using MediatR;

namespace InstaConnect.Shared.Application.Abstractions;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand;

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>;
