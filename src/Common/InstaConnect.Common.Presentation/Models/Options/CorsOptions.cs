using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Common.Presentation.Models.Options;

public class CorsOptions
{
    [Required]
    public string AllowedOrigins { get; set; } = string.Empty;
}
