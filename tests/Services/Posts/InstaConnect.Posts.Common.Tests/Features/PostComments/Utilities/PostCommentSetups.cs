using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
public static class PostCommentSetups
{
    public static IPostCommentRepository GetPostCommentRepository(this IServiceScope serviceScope)
    {
        var postCommentRepository = serviceScope.ServiceProvider.GetRequiredService<IPostCommentRepository>();

        return postCommentRepository;
    }

    public static async Task<PostComment?> GetPostCommentByIdAsync(
        this IServiceScope serviceScope,
        string id,
        string commentId,
        CancellationToken cancellationToken)
    {
        var postCommentRepository = serviceScope.GetPostCommentRepository();
        var postComment = await postCommentRepository.GetByIdAsync(id, commentId, cancellationToken);

        return postComment;
    }

    public static async Task AddPostCommentAsync(
        this IServiceScope serviceScope,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var unitOfWork = serviceScope.GetUnitOfWork();
        var postCommentRepository = serviceScope.GetPostCommentRepository();

        postCommentRepository.Add(postComment);
        await unitOfWork.CommitAsync(cancellationToken);
    }

    public static async Task DeletePostCommentAsync(
        this IServiceScope serviceScope,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var unitOfWork = serviceScope.GetUnitOfWork();
        var postCommentRepository = serviceScope.GetPostCommentRepository();

        postCommentRepository.Delete(postComment);
        await unitOfWork.CommitAsync(cancellationToken);
    }

    public static async Task ResetPostCommentDatabase(
        this IServiceScope serviceScope,
        CancellationToken cancellationToken)
    {
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<PostsContext>();

        if (await dbContext.PostComments.AnyAsync(cancellationToken))
        {
            await dbContext.PostComments.ExecuteDeleteAsync(cancellationToken);
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
