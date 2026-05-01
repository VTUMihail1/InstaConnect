using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Observability.Models;

public class OpenTelemetryOptions : IApplicationOptions
{
	public const string SectionName = "OpenTelemetryConfiguration";

	[Required]
	public string Endpoint { get; set; } = string.Empty;
}
