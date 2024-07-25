using MediatR;

namespace InstaConnect.Shared.Business.Abstractions;

public interface ICommand : IRequest;

public interface ICommand<TResponse> : IRequest<TResponse>;
