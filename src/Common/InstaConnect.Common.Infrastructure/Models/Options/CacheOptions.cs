namespace InstaConnect.Common.Infrastructure.Models.Options;
public class CacheOptions
{
    [Required]
    public string ConnectionString { get; set; } = string.Empty;
}
