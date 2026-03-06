namespace InstaConnect.Posts.Domain.Features.PostLikes.Extensions;

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
