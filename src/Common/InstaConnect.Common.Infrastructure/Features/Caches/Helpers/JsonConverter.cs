using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;

using Newtonsoft.Json;

namespace InstaConnect.Common.Infrastructure.Features.Caches.Helpers;

internal class JsonConverter : IJsonConverter
{
	public T? Deserialize<T>(string? value)
	{
		var obj = JsonConvert.DeserializeObject<T>(value ?? string.Empty);

		return obj;
	}

	public string Serialize(object? obj)
	{
		var value = JsonConvert.SerializeObject(obj) ?? string.Empty;

		return value;
	}
}
