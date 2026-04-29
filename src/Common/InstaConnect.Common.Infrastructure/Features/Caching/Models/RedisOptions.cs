using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Caching.Models;

public class RedisOptions : IApplicationOptions
{
	public const string SectionName = "RedisConfiguration";

	public string ConnectionString { get; set; } = string.Empty;
}
