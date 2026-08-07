using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Extensions;

public static class BusRegistrationConfiguratorExtension
{
	extension(IBusRegistrationConfigurator busConfigurator)
	{
		public IBusRegistrationConfigurator SetKebabCaseEndpointNameFormatterWithPrefix(string prefix)
		{
			busConfigurator.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(prefix, false));

			return busConfigurator;
		}
	}
}
