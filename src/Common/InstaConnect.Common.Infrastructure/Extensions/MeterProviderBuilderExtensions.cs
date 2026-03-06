using MassTransit.Monitoring;

using OpenTelemetry.Metrics;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class MeterProviderBuilderExtensions
{
    extension(MeterProviderBuilder meterProviderBuilder)
    {
        public MeterProviderBuilder AddMassTransitInstrumentation()
        {
            meterProviderBuilder.AddMeter(InstrumentationOptions.MeterName);

            return meterProviderBuilder;
        }
    }
}
