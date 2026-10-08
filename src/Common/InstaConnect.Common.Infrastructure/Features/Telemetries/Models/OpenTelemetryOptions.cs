using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Telemetries.Models;

public record OpenTelemetryOptions(
	string Endpoint) : IApplicationOptions
{
	public const string SectionName = "OpenTelemetryConfiguration";
}
