using MediatR;

namespace InstaConnect.Common.Application.Helpers;

internal class ApplicationSender : IApplicationSender
{
    private readonly ISender _sender;

    public ApplicationSender(ISender sender)
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
