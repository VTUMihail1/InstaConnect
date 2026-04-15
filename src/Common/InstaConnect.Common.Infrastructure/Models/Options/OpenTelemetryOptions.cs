using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Common.Infrastructure.Models.Options;

public class OpenTelemetryOptions : IApplicationOptions
{
    public const string SectionName = "OpenTelemetryConfiguration";

    [Required]
    public string Endpoint { get; set; } = string.Empty;
}
