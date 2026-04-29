namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddEmailConfirmationTokenServices()
		{
			return serviceCollection;
		}
	}
}
