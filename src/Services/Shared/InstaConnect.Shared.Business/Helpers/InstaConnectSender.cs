using InstaConnect.Shared.Business.Abstractions;
using MediatR;

namespace InstaConnect.Shared.Business.Helpers;

internal class InstaConnectSender : IInstaConnectSender
{
    private readonly ISender _sender;

    public InstaConnectSender(ISender sender)
    {
        _sender = sender;
    }

    public async Task Send<TRequest>(TRequest request, CancellationToken cancellationToken) where TRequest : IRequest
    {
        await _sender.Send(request, cancellationToken);
    }

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);

        return response;
    }
}
