using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstract;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostCommentLikeServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
