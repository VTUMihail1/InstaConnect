using MediatR;

namespace InstaConnect.Common.Application.Abstractions;

public interface IQuery : IBaseRequest;

public interface IQueryRequest<out TResponse> : IRequest<TResponse>, IQuery;
