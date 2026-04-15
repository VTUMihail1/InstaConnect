using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Common.Presentation.Models.Options;

public class CorsOptions : IApplicationOptions
{
    public const string SectionName = "CorsConfiguration";

    [Required]
    public string AllowedOrigins { get; set; } = string.Empty;
}
