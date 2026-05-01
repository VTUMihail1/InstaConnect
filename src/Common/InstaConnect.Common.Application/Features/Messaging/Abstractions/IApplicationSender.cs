using MediatR;

namespace InstaConnect.Common.Application.Features.Messaging.Abstractions;

public interface IApplicationSender
{
	public Task SendAsync<TRequest>(TRequest request, CancellationToken cancellationToken) where TRequest : IRequest;

	public Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken);
}
