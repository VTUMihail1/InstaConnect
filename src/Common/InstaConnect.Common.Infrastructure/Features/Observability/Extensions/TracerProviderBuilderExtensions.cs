using MassTransit.Logging;

using OpenTelemetry.Trace;

namespace InstaConnect.Common.Infrastructure.Features.Observability.Extensions;

public static class TracerProviderBuilderExtensions
{
	extension(TracerProviderBuilder tracerProviderBuilder)
	{
		public TracerProviderBuilder AddMassTransitInstrumentation()
		{
			tracerProviderBuilder.AddSource(DiagnosticHeaders.DefaultListenerName);
			return tracerProviderBuilder;
		}
	}
}
