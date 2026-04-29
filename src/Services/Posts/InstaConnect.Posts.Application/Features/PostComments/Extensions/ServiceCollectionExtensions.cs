namespace InstaConnect.Posts.Application.Features.PostComments.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddPostCommentServices()
		{
			return serviceCollection;
		}
	}
}
