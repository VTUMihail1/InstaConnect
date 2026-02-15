using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Common.Presentation.Models.Options;

public class CorsOptions
{
    public const string SectionName = "CorsConfiguration";

    [Required]
    public string AllowedOrigins { get; set; } = string.Empty;
}
