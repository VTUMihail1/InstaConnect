namespace InstaConnect.Identity.Domain.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddUserServices()
		{
			return serviceCollection;
		}
	}
}
