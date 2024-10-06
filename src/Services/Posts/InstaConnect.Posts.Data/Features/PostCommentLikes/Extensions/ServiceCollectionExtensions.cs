using InstaConnect.Posts.Data.Features.PostCommentLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Data.Features.PostCommentLikes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostCommentLikeServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IPostCommentLikeReadRepository, PostCommentLikeReadRepository>()
            .AddScoped<IPostCommentLikeWriteRepository, PostCommentLikeWriteRepository>();

        return serviceCollection;
    }
}
