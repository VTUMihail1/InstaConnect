using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;
public static class PostCommentSetups
{
    public static IPostCommentCommandRepository GetPostCommentCommandRepository(this IServiceScope serviceScope)
    {
        return serviceScope.ServiceProvider.GetRequiredService<IPostCommentCommandRepository>();
    }

    public static async Task<PostComment?> GetPostCommentByIdAsync(
        this IServiceScope serviceScope,
        PostCommentId id,
        CancellationToken cancellationToken)
    {
        var postCommentRepository = serviceScope.GetPostCommentCommandRepository();

        return await postCommentRepository.GetByIdAsync(id, cancellationToken);
    }

    public static async Task AddPostCommentAsync(
        this IServiceScope serviceScope,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var postCommentRepository = serviceScope.GetPostCommentCommandRepository();

        await postCommentRepository.AddAsync(postComment, cancellationToken);
    }

    public static async Task AddPostCommentRangeAsync(
        this IServiceScope serviceScope,
        IEnumerable<PostComment> postComments,
        CancellationToken cancellationToken)
    {
        var postCommentRepository = serviceScope.GetPostCommentCommandRepository();

        await postCommentRepository.AddRangeAsync(postComments, cancellationToken);
    }

    public static async Task DeletePostCommentAsync(
        this IServiceScope serviceScope,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var postCommentRepository = serviceScope.GetPostCommentCommandRepository();

        await postCommentRepository.DeleteAsync(postComment, cancellationToken);
    }

    public static async Task ResetPostCommentDatabase(
        this IServiceScope serviceScope,
        CancellationToken cancellationToken)
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<IPostsContext>();

        await context.PostCommentLikes.ResetAsync(cancellationToken);
        await context.PostComments.ResetAsync(cancellationToken);
        await context.PostLikes.ResetAsync(cancellationToken);
        await context.Posts.ResetAsync(cancellationToken);
        await context.Users.ResetAsync(cancellationToken);
    }
}
