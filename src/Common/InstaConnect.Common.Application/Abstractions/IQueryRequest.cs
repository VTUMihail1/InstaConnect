namespace InstaConnect.Common.Application.Abstractions;

public interface IQuery;

public interface IQueryRequest<out TResponse> : IRequest<TResponse>, IQuery;
