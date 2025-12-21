using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
    public static async Task ShouldReceiveOneGetAllAsync(
        this IPostCommentLikeService postCommentLikeService,
        GetAllPostCommentLikesQueryRequest request,
        CommonIncludeQuery<PostCommentLikeIncludeProperty> include,
        CancellationToken cancellationToken)
    {
        await postCommentLikeService.ShouldHaveReceived(1).GetAllAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQuery(request, include), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(
        this IPostCommentLikeService postCommentLikeService,
        GetPostCommentLikeByIdQueryRequest request,
        CommonIncludeQuery<PostCommentLikeIncludeProperty> include,
        CancellationToken cancellationToken)
    {
        await postCommentLikeService.ShouldHaveReceived(1).GetByIdAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQuery(request, include), cancellationToken);
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
