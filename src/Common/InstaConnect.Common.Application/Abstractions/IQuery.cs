namespace InstaConnect.Common.Application.Abstractions;

public interface IQuery<out TResponse> : IRequest<TResponse>;
