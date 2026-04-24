using MediatR;

namespace InstaConnect.Common.Application.Features.Messaging.Abstractions;

public interface IQuery : IBaseRequest;

public interface IQueryRequest<out TResponse> : IRequest<TResponse>, IQuery;
