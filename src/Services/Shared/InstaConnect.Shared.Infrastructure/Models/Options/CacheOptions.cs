using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Shared.Data.Models.Options;
public class CacheOptions
{
    [Required]
    public string ConnectionString { get; set; } = string.Empty;
}
