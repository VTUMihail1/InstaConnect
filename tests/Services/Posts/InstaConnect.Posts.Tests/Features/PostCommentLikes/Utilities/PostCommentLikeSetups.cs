using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeSetups
{
    public static IPostCommentLikeRepository GetPostCommentLikeRepository(this IServiceScope serviceScope)
    {
        var postCommentLikeRepository = serviceScope.ServiceProvider.GetRequiredService<IPostCommentLikeRepository>();

        return postCommentLikeRepository;
    }

    public static async Task<PostCommentLike?> GetPostCommentLikeByIdAsync(
        this IServiceScope serviceScope,
        PostCommentLikeId id,
        CancellationToken cancellationToken)
    {
        var postCommentLikeRepository = serviceScope.GetPostCommentLikeRepository();

        return await postCommentLikeRepository.GetByIdAsync(id, cancellationToken);
    }

    public static async Task AddPostCommentLikeAsync(
        this IServiceScope serviceScope,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var postCommentLikeRepository = serviceScope.GetPostCommentLikeRepository();

        await postCommentLikeRepository.AddAsync(postCommentLike, cancellationToken);
    }

    public static async Task AddPostCommentLikeRangeAsync(
        this IServiceScope serviceScope,
        IEnumerable<PostCommentLike> postCommentLikes,
        CancellationToken cancellationToken)
    {
        var postCommentLikeRepository = serviceScope.GetPostCommentLikeRepository();

        await postCommentLikeRepository.AddRangeAsync(postCommentLikes, cancellationToken);
    }

    public static async Task DeletePostCommentLikeAsync(
        this IServiceScope serviceScope,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var postCommentLikeRepository = serviceScope.GetPostCommentLikeRepository();

        await postCommentLikeRepository.DeleteAsync(postCommentLike, cancellationToken);
    }

    public static async Task ResetPostCommentLikeDatabase(
        this IServiceScope serviceScope,
        CancellationToken cancellationToken)
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<IPostsContext>();

        await context.PostCommentLikes.ResetAsync(cancellationToken);
        await context.PostComments.ResetAsync(cancellationToken);
        await context.Posts.ResetAsync(cancellationToken);
        await context.Users.ResetAsync(cancellationToken);
    }
}
