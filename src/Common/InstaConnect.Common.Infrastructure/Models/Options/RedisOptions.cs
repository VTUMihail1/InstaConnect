using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Common.Infrastructure.Models.Options;

public class RedisOptions : IApplicationOptions
{
    public const string SectionName = "RedisConfiguration";

    public string ConnectionString { get; set; } = string.Empty;
}
