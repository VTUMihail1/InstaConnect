using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Infrastructure.Models.Options;
public class CacheOptions
{
    public const string SectionName = "CacheConfiguration";

    [Required]
    public string ConnectionString { get; set; } = string.Empty;
}
