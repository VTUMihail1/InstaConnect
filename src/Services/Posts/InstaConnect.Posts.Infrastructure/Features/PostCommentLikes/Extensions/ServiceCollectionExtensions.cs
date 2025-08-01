using InstaConnect.Common.Extensions;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Extensions;

namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostCommentLikeServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IPostCommentLikeSortProperty>(PostInfrastructureReference.Assembly);

        return serviceCollection;
    }
}
