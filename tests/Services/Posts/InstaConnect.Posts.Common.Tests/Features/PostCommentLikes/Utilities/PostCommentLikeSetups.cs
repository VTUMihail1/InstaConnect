using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.Posts.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeSetups
{
    public static IPostCommentLikeRepository GetPostCommentLikeRepository(this IServiceScope serviceScope)
    {
        var postCommentLikeRepository = serviceScope.ServiceProvider.GetRequiredService<IPostCommentLikeRepository>();

        return postCommentLikeRepository;
    }

    public static async Task<PostCommentLike?> GetPostCommentLikeByIdAsync(
        this IServiceScope serviceScope,
        string id,
        string commentId,
        string commentLikeId,
        CancellationToken cancellationToken)
    {
        var postCommentLikeRepository = serviceScope.GetPostCommentLikeRepository();
        var postCommentLike = await postCommentLikeRepository.GetByIdAsync(id, commentId, commentLikeId, cancellationToken);

        return postCommentLike;
    }

    public static async Task<PostCommentLike> AddPostCommentLikeAsync(
        this IServiceScope serviceScope,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var unitOfWork = serviceScope.GetUnitOfWork();
        var postCommentLikeRepository = serviceScope.GetPostCommentLikeRepository();

        postCommentLikeRepository.Add(postCommentLike);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return postCommentLike;
    }

    public static async Task ResetPostCommentLikeDatabase(
        this IServiceScope serviceScope,
        CancellationToken cancellationToken)
    {
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<PostsContext>();

        if (await dbContext.PostCommentLikes.AnyAsync(cancellationToken))
        {
            await dbContext.PostCommentLikes.ExecuteDeleteAsync(cancellationToken);
        }

        if (await dbContext.Posts.AnyAsync(cancellationToken))
        {
            await dbContext.Posts.ExecuteDeleteAsync(cancellationToken);
        }

        if (await dbContext.Users.AnyAsync(cancellationToken))
        {
            await dbContext.Users.ExecuteDeleteAsync(cancellationToken);
        }
    }
}
