using MassTransit.Monitoring;

using OpenTelemetry.Metrics;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class MeterProviderBuilderExtensions
{
    public static MeterProviderBuilder AddMassTransitInstrumentation(this MeterProviderBuilder meterProviderBuilder)
    {
        meterProviderBuilder.AddMeter(InstrumentationOptions.MeterName);

        return meterProviderBuilder;
    }
}
