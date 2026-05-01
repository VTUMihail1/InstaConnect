namespace InstaConnect.Identity.Application.Features.Users.Extensions;

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
