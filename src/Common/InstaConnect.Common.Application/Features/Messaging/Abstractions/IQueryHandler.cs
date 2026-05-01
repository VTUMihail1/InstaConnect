using MediatR;

namespace InstaConnect.Common.Application.Features.Messaging.Abstractions;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
	where TQuery : IQueryRequest<TResponse>;
