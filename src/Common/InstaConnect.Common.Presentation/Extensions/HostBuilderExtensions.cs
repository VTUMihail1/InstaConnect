using Microsoft.Extensions.Hosting;

using Serilog;

namespace InstaConnect.Common.Presentation.Extensions;

public static class HostBuilderExtensions
{
    extension(IHostBuilder hostBuilder)
    {
        public IHostBuilder AddSerilog()
        {
            hostBuilder.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));

            return hostBuilder;
        }
    }
}
