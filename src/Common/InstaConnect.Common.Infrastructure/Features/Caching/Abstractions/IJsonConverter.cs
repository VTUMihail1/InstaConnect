namespace InstaConnect.Common.Infrastructure.Features.Caching.Abstractions;

public interface IJsonConverter
{
	public T? Deserialize<T>(string value);
	public string Serialize(object? obj);
}
