namespace InstaConnect.Shared.Data.Abstractions;

public interface ICacheHandler
{
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken);
    Task SetAsync(string key, object obj, CancellationToken cancellationToken);
}
