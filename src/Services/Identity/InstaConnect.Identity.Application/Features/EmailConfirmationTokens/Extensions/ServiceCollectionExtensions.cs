namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddEmailConfirmationTokenServices()
		{
			return serviceCollection;
		}
	}
}
