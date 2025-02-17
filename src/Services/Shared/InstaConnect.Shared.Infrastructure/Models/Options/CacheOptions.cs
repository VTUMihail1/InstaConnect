namespace InstaConnect.Shared.Infrastructure.Models.Options;
public class CacheOptions
{
    [Required]
    public string ConnectionString { get; set; } = string.Empty;
}
