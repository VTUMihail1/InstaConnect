namespace InstaConnect.Common.Infrastructure.Features.Caching.Abstractions;

public interface IJsonConverter
{
    T? Deserialize<T>(string value);
    string Serialize(object? obj);
}
