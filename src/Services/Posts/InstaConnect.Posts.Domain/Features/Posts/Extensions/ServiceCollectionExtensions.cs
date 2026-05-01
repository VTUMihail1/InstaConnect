namespace InstaConnect.Posts.Domain.Features.Posts.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddPostServices()
		{
			return serviceCollection;
		}
	}
}
