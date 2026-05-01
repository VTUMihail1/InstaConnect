namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddPostCommentLikeServices()
		{
			return serviceCollection;
		}
	}
}
