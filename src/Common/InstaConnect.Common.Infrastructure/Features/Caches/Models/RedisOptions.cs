using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Caches.Models;

public record RedisOptions(
	string ConnectionString) : IApplicationOptions
{
	public const string SectionName = "RedisConfiguration";
}
