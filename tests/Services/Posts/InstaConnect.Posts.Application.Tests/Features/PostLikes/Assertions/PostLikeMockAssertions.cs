using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeMockAssertions
{
    public static async Task ShouldReceiveOneGetAllAsync(
        this IPostLikeService postLikeService,
        GetAllPostLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postLikeService.ShouldHaveReceived(1).GetAllAsync(PostLikeMatcher.IsGetAllPostLikesQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(
        this IPostLikeService postLikeService,
        GetPostLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postLikeService.ShouldHaveReceived(1).GetByIdAsync(PostLikeMatcher.IsGetPostLikeByIdQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneAddAsync(
        this IPostLikeService postLikeService,
        AddPostLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postLikeService.ShouldHaveReceived(1).AddAsync(PostLikeMatcher.IsAddPostLikeCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneDeleteAsync(
        this IPostLikeService postLikeService,
        DeletePostLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postLikeService.ShouldHaveReceived(1).DeleteAsync(PostLikeMatcher.IsDeletePostLikeCommand(request), cancellationToken);
    }
}
