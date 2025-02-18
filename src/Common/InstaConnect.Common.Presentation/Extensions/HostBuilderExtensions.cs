using Serilog;

namespace InstaConnect.Shared.Presentation.Extensions;

public static class HostBuilderExtensions
{
    public static IHostBuilder AddSerilog(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));

        return hostBuilder;
    }
}
