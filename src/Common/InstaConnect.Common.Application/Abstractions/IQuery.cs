namespace InstaConnect.Common.Application.Abstractions;

public interface IBaseQuery;

public interface IQuery<out TResponse> : IRequest<TResponse>, IBaseQuery;
