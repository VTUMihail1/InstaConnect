using InstaConnect.Shared.Business.Abstractions;
using MassTransit;

namespace InstaConnect.Shared.Business.Helpers;

internal class InstaConnectRequestClient<T> : IInstaConnectRequestClient<T> where T : class
{
    private readonly IRequestClient<T> _requestClient;

    public InstaConnectRequestClient(IRequestClient<T> requestClient)
    {
        _requestClient = requestClient;
    }

    public async Task<TResponse?> GetResponseMessageAsync<TResponse>(T request, CancellationToken cancellationToken)
        where TResponse : class
    {
        var response = await _requestClient.GetResponse<TResponse>(request, cancellationToken);

        return response.Message;
    }
}
