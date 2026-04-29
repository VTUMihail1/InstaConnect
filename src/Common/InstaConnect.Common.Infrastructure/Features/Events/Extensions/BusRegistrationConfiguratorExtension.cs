using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Extensions;

public static class BusRegistrationConfiguratorExtension
{
	public static IBusRegistrationConfigurator SetKebabCaseEndpointNameFormatterWithPrefix(
		this IBusRegistrationConfigurator busConfigurator, string prefix)
	{
		busConfigurator.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(prefix, false));

		return busConfigurator;
	}
}
