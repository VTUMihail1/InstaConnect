using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Shared.Business.Models.Options;
public class CacheOptions
{
    [Required]
    public string ConnectionString { get; set; } = string.Empty;
}
