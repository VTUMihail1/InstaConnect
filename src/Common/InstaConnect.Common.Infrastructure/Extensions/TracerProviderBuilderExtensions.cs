using MassTransit.Logging;

using OpenTelemetry.Trace;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class TracerProviderBuilderExtensions
{
    public static TracerProviderBuilder AddMassTransitInstrumentation(this TracerProviderBuilder tracerProviderBuilder)
    {
        tracerProviderBuilder.AddSource(DiagnosticHeaders.DefaultListenerName);

        return tracerProviderBuilder;
    }
}
