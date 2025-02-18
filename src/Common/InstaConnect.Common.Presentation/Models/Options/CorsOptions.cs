using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Shared.Presentation.Models.Options;

public class CorsOptions
{
    [Required]
    public string AllowedOrigins { get; set; } = string.Empty;
}
