namespace InstaConnect.Posts.Presentation.Features.PostLikes.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddPostLikeServices()
		{
			return serviceCollection;
		}
	}
}
