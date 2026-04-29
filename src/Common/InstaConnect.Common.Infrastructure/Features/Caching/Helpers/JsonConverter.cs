using InstaConnect.Common.Infrastructure.Features.Caching.Abstractions;

using Newtonsoft.Json;

namespace InstaConnect.Common.Infrastructure.Features.Caching.Helpers;

internal class JsonConverter : IJsonConverter
{
	public T? Deserialize<T>(string value)
	{
		var obj = JsonConvert.DeserializeObject<T>(value);

		return obj;
	}

	public string Serialize(object? obj)
	{
		var value = JsonConvert.SerializeObject(obj);

		return value;
	}
}
