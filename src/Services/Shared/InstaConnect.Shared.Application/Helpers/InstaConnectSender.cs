using InstaConnect.Shared.Application.Abstractions;
using MediatR;

namespace InstaConnect.Shared.Application.Helpers;

internal class InstaConnectSender : IInstaConnectSender
{
    private readonly ISender _sender;

    public InstaConnectSender(ISender sender)
    {
        _sender = sender;
    }

    public async Task SendAsync<TRequest>(TRequest request, CancellationToken cancellationToken) where TRequest : IRequest
    {
        await _sender.Send(request, cancellationToken);
    }

    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);

        return response;
    }
}
