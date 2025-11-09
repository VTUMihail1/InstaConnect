using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
    public static async Task ShouldReceiveOneGetAllAsync(
        this IPostCommentLikeService postCommentLikeService,
        GetAllPostCommentLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentLikeService.ShouldHaveReceived(1).GetAllAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(
        this IPostCommentLikeService postCommentLikeService,
        GetPostCommentLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentLikeService.ShouldHaveReceived(1).GetByIdAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneAddAsync(
        this IPostCommentLikeService postCommentLikeService,
        AddPostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentLikeService.ShouldHaveReceived(1).AddAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneDeleteAsync(
        this IPostCommentLikeService postCommentLikeService,
        DeletePostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentLikeService.ShouldHaveReceived(1).DeleteAsync(PostCommentLikeMatcher.IsDeletePostCommentLikeCommand(request), cancellationToken);
    }
}
