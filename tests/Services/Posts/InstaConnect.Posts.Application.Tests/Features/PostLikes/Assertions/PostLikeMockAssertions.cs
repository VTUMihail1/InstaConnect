using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeMockAssertions
{
    public static async Task ShouldReceiveOneGetAllAsync(
        this IPostLikeQueryService postLikeService,
        GetAllPostLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postLikeService.ShouldHaveReceivedOne().GetAllAsync(PostLikeMatcher.IsGetAllPostLikesQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetAllForUserAsync(
        this IPostLikeQueryService postLikeService,
        GetAllPostLikesForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postLikeService.ShouldHaveReceivedOne().GetAllForUserAsync(PostLikeMatcher.IsGetAllPostLikesForUserQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(
        this IPostLikeQueryService postLikeService,
        GetPostLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postLikeService.ShouldHaveReceivedOne().GetByIdAsync(PostLikeMatcher.IsGetPostLikeByIdQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneAddAsync(
        this IPostLikeCommandService postLikeService,
        AddPostLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postLikeService.ShouldHaveReceivedOne().AddAsync(PostLikeMatcher.IsAddPostLikeCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneDeleteAsync(
        this IPostLikeCommandService postLikeService,
        DeletePostLikeCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postLikeService.ShouldHaveReceivedOne().DeleteAsync(PostLikeMatcher.IsDeletePostLikeCommand(request), cancellationToken);
    }
}
