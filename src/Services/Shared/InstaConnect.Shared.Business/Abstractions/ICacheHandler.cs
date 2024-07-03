namespace InstaConnect.Shared.Business.Abstractions;

internal interface ICacheHandler
{
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken);
    Task SetAsync(string key, object obj, CancellationToken cancellationToken);
}