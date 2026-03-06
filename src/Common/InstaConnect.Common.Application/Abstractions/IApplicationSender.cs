using MediatR;

namespace InstaConnect.Common.Application.Abstractions;

public interface IApplicationSender
{
    Task SendAsync<TRequest>(TRequest request, CancellationToken cancellationToken) where TRequest : IRequest;

    Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken);
}
