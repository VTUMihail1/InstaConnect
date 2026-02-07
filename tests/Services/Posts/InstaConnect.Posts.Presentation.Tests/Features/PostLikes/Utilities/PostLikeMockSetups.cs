namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
public static class PostLikeMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender sender,
        GetAllPostLikesApiRequest request,
        Post post,
        ICollection<PostLike> postLikes,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostLikeMatcher.IsGetAllPostLikesQueryRequest(request), cancellationToken)
            .ReturnsResponse(postLikes.ToResponse(post, request));
    }

    public static void SetupGetAllForUserQueryRequest(
        this IApplicationSender sender,
        GetAllPostLikesForUserApiRequest request,
        User user,
        ICollection<PostLike> postLikes,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostLikeMatcher.IsGetAllPostLikesForUserQueryRequest(request), cancellationToken)
            .ReturnsResponse(postLikes.ToResponse(user, request));
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender sender,
        GetPostLikeByIdApiRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostLikeMatcher.IsGetPostLikeByIdQueryRequest(request), cancellationToken)
            .ReturnsResponse(postLike.ToResponse(request));
    }

    public static void SetupAddCommandRequest(
        this IApplicationSender sender,
        AddPostLikeApiRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostLikeMatcher.IsAddPostLikeCommandRequest(request), cancellationToken)
            .ReturnsResponse(postLike.ToResponse(request));
    }
}
