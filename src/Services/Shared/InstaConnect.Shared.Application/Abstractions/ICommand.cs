using MediatR;

namespace InstaConnect.Shared.Application.Abstractions;

public interface ICommand : IRequest;

public interface ICommand<TResponse> : IRequest<TResponse>;
