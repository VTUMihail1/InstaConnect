namespace InstaConnect.Common.Infrastructure.Models.Options;
public class CacheOptions
{
    public const string SectionName = "CacheConfiguration";

    public string ConnectionString { get; set; } = string.Empty;
}
