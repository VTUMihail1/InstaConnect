using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
public static class PostLikeSetups
{
    public static IPostLikeRepository GetPostLikeRepository(this IServiceScope serviceScope)
    {
        var postLikeRepository = serviceScope.ServiceProvider.GetRequiredService<IPostLikeRepository>();

        return postLikeRepository;
    }

    public static async Task<PostLike?> GetPostLikeByIdAsync(
        this IServiceScope serviceScope,
        string id,
        string userId,
        CancellationToken cancellationToken)
    {
        var postLikeRepository = serviceScope.GetPostLikeRepository();
        var postLike = await postLikeRepository.GetByIdAsync(id, userId, cancellationToken);

        return postLike;
    }

    public static async Task AddPostLikeAsync(
        this IServiceScope serviceScope,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var unitOfWork = serviceScope.GetUnitOfWork();
        var postLikeRepository = serviceScope.GetPostLikeRepository();

        postLikeRepository.Add(postLike);
        await unitOfWork.CommitAsync(cancellationToken);
    }

    public static async Task DeletePostLikeAsync(
        this IServiceScope serviceScope,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var unitOfWork = serviceScope.GetUnitOfWork();
        var postLikeRepository = serviceScope.GetPostLikeRepository();

        postLikeRepository.Delete(postLike);
        await unitOfWork.CommitAsync(cancellationToken);
    }

    public static async Task ResetPostLikeDatabase(
        this IServiceScope serviceScope,
        CancellationToken cancellationToken)
    {
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<PostsContext>();

        if (await dbContext.PostLikes.AnyAsync(cancellationToken))
        {
            await dbContext.PostLikes.ExecuteDeleteAsync(cancellationToken);
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
