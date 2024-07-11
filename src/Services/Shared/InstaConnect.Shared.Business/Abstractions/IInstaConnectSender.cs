using MediatR;

namespace InstaConnect.Shared.Business.Abstractions;
public interface IInstaConnectSender
{
    Task Send<TRequest>(TRequest request, CancellationToken cancellationToken) where TRequest : IRequest;

    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken);
}
