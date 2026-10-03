using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Caches.Models;

public class RedisOptions : IApplicationOptions
{
	public const string SectionName = "RedisConfiguration";

	[Required]
	public string ConnectionString { get; set; } = string.Empty;
}
