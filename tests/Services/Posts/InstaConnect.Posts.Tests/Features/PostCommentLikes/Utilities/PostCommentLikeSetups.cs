using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Infrastructure.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeSetups
{
    public static IPostCommentLikeCommandRepository GetPostCommentLikeCommandRepository(this IServiceScope serviceScope)
    {
        return serviceScope.ServiceProvider.GetRequiredService<IPostCommentLikeCommandRepository>();
    }

    public static IPostCommentLikeIncludeBuilderFactory GetPostCommentLikeIncludeBuilderFactory(this IServiceScope serviceScope)
    {
        return serviceScope.ServiceProvider.GetRequiredService<IPostCommentLikeIncludeBuilderFactory>();
    }

    public static async Task<PostCommentLike?> GetPostCommentLikeByIdAsync(
        this IServiceScope serviceScope,
        PostCommentLikeId id,
        CancellationToken cancellationToken)
    {
        var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();
        var commentInclude = serviceScope.GetPostCommentIncludeBuilderFactory().Create().WithUser().WithPost(include).Build();
        var commentLikeInclude = serviceScope.GetPostCommentLikeIncludeBuilderFactory().Create().WithPostComment(commentInclude).WithUser().Build();
        var postCommentLikeRepository = serviceScope.GetPostCommentLikeCommandRepository();

        return await postCommentLikeRepository.GetByIdAsync(id, commentLikeInclude, cancellationToken);
    }

    public static async Task AddPostCommentLikeAsync(
        this IServiceScope serviceScope,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var postCommentLikeRepository = serviceScope.GetPostCommentLikeCommandRepository();

        await postCommentLikeRepository.AddAsync(postCommentLike, cancellationToken);
    }

    public static async Task AddPostCommentLikeRangeAsync(
        this IServiceScope serviceScope,
        IEnumerable<PostCommentLike> postCommentLikes,
        CancellationToken cancellationToken)
    {
        var postCommentLikeRepository = serviceScope.GetPostCommentLikeCommandRepository();

        await postCommentLikeRepository.AddRangeAsync(postCommentLikes, cancellationToken);
    }

    public static async Task DeletePostCommentLikeAsync(
        this IServiceScope serviceScope,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var postCommentLikeRepository = serviceScope.GetPostCommentLikeCommandRepository();

        await postCommentLikeRepository.DeleteAsync(postCommentLike, cancellationToken);
    }

    public static async Task ResetPostCommentLikeDatabase(
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
