namespace InstaConnect.Common.Application.Abstractions;

public interface ICommand : IRequest;

public interface ICommand<TResponse> : IRequest<TResponse>;
