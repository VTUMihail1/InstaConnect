using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeMockSetups
{
    public static void SetupGetAllQuery(
        this IPostCommentLikeQueryService commentLikeService,
        GetAllPostCommentLikesQueryRequest request,
        ICollection<PostCommentLike> postCommentLikes,
        CancellationToken cancellationToken)
    {
        commentLikeService
            .GetAllAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQuery(request), cancellationToken)
            .ReturnsResponse(postCommentLikes.ToResponse(request));
    }

    public static void SetupGetAllForUserQuery(
        this IPostCommentLikeQueryService commentLikeService,
        GetAllPostCommentLikesForUserQueryRequest request,
        ICollection<PostCommentLike> postCommentLikes,
        CancellationToken cancellationToken)
    {
        commentLikeService
            .GetAllForUserAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesForUserQuery(request), cancellationToken)
            .ReturnsResponse(postCommentLikes.ToResponse(request));
    }

    public static void SetupGetByIdQuery(
        this IPostCommentLikeQueryService commentLikeService,
        GetPostCommentLikeByIdQueryRequest request,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        commentLikeService
            .GetByIdAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQuery(request), cancellationToken)
            .ReturnsResponse(postCommentLike.ToResponse(request));
    }

    public static void SetupAddCommand(
        this IPostCommentLikeCommandService commentLikeService,
        AddPostCommentLikeCommandRequest request,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        commentLikeService
            .AddAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommand(request), cancellationToken)
            .ReturnsResponse(postCommentLike.ToResponse(request));
    }
}
