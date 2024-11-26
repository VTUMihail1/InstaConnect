using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostCommentLikeServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
