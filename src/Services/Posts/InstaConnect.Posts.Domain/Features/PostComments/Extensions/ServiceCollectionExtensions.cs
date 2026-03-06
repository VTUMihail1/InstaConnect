namespace InstaConnect.Posts.Domain.Features.PostComments.Extensions;

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
