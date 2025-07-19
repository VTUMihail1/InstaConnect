using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Common.Infrastructure.Models.Options;

public class OpenTelemetryOptions
{
    public const string SectionName = nameof(OpenTelemetryOptions);

    [Required]
    public string Endpoint { get; set; } = string.Empty;
}
