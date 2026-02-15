using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Common.Infrastructure.Models.Options;

public class OpenTelemetryOptions
{
    public const string SectionName = "OpenTelemetryConfiguration";

    [Required]
    public string Endpoint { get; set; } = string.Empty;
}
