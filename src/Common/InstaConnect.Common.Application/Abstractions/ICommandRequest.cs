using MediatR;

namespace InstaConnect.Common.Application.Abstractions;

public interface ICommand;

public interface ICommandRequest : IRequest, ICommand;

public interface ICommandRequest<out TResponse> : IRequest<TResponse>, ICommand;
