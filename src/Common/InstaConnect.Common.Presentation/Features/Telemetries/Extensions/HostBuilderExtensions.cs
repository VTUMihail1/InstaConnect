using Microsoft.Extensions.Hosting;

using Serilog;

namespace InstaConnect.Common.Presentation.Features.Telemetries.Extensions;

public static class HostBuilderExtensions
{
	extension(IHostBuilder hostBuilder)
	{
		public IHostBuilder UseTelemetries()
		{
			hostBuilder.UseSerilog((context, configuration) =>
				configuration.ReadFrom.Configuration(context.Configuration));

			return hostBuilder;
		}
	}
}
