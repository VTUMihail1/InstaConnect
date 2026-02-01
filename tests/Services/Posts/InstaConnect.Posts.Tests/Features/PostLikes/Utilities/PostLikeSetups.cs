using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
public static class PostLikeSetups
{
    public static IPostLikeCommandRepository GetPostLikeCommandRepository(this IServiceScope serviceScope)
    {
        return serviceScope.ServiceProvider.GetRequiredService<IPostLikeCommandRepository>();
    }

    public static async Task<PostLike?> GetPostLikeByIdAsync(
        this IServiceScope serviceScope,
        PostLikeId id,
        CancellationToken cancellationToken)
    {
        var postLikeRepository = serviceScope.GetPostLikeCommandRepository();

        return await postLikeRepository.GetByIdAsync(id, cancellationToken);
    }

    public static async Task AddPostLikeAsync(
        this IServiceScope serviceScope,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var postLikeRepository = serviceScope.GetPostLikeCommandRepository();

        await postLikeRepository.AddAsync(postLike, cancellationToken);
    }

    public static async Task AddPostLikeRangeAsync(
        this IServiceScope serviceScope,
        IEnumerable<PostLike> postLikes,
        CancellationToken cancellationToken)
    {
        var postLikeRepository = serviceScope.GetPostLikeCommandRepository();

        await postLikeRepository.AddRangeAsync(postLikes, cancellationToken);
    }

    public static async Task DeletePostLikeAsync(
        this IServiceScope serviceScope,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var postLikeRepository = serviceScope.GetPostLikeCommandRepository();

        await postLikeRepository.DeleteAsync(postLike, cancellationToken);
    }

    public static async Task ResetPostLikeDatabase(
        this IServiceScope serviceScope,
        CancellationToken cancellationToken)
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<IPostsContext>();

        await context.PostLikes.ResetAsync(cancellationToken);
        await context.Posts.ResetAsync(cancellationToken);
        await context.Users.ResetAsync(cancellationToken);
    }
}
