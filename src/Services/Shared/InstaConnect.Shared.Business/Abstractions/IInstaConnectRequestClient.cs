namespace InstaConnect.Shared.Business.Abstractions;

public interface IInstaConnectRequestClient<T> where T : class
{
    Task<TResponse?> GetResponseMessageAsync<TResponse>(T request, CancellationToken cancellationToken) where TResponse : class;
}
