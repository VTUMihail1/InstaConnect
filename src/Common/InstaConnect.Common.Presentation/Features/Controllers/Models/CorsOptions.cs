using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Presentation.Features.Controllers.Models;

public class CorsOptions : IApplicationOptions
{
    public const string SectionName = "CorsConfiguration";

    [Required]
    public string AllowedOrigins { get; set; } = string.Empty;
}
