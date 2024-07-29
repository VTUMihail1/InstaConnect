using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostCommentLikeServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
