using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
    public static async Task ShouldReceiveOneGetAllAsync(
        this IPostCommentLikeQueryService postCommentLikeService,
        GetAllPostCommentLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentLikeService.ShouldHaveReceivedOne().GetAllAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetAllForUserAsync(
        this IPostCommentLikeQueryService postCommentLikeService,
        GetAllPostCommentLikesForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentLikeService.ShouldHaveReceivedOne().GetAllForUserAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesForUserQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(
        this IPostCommentLikeQueryService postCommentLikeService,
        GetPostCommentLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentLikeService.ShouldHaveReceivedOne().GetByIdAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneAddAsync(
        this IPostCommentLikeCommandService postCommentLikeService,
        AddPostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentLikeService.ShouldHaveReceivedOne().AddAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneDeleteAsync(
        this IPostCommentLikeCommandService postCommentLikeService,
        DeletePostCommentLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentLikeService.ShouldHaveReceivedOne().DeleteAsync(PostCommentLikeMatcher.IsDeletePostCommentLikeCommand(request), cancellationToken);
    }
}
