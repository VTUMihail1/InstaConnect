namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender applicationSender,
        GetAllPostCommentLikesApiRequest request,
        PostCommentLike postCommentLike,
        User user,
        CancellationToken cancellationToken)
    {

        var postCommentLikeQueryResponse = new PostCommentLikeQueryResponse(
            postCommentLike.Id,
            postCommentLike.CommentId,
            new(
                user.Id,
                user.Name,
                user.ProfileImage));
        var postCommentLikeQueryResponses = new List<PostCommentLikeQueryResponse>() { postCommentLikeQueryResponse };

        var response = new GetAllPostCommentLikesQueryResponse(
            postCommentLikeQueryResponses,
            request.Pagination.Page,
            request.Pagination.PageSize,
            postCommentLikeQueryResponses.Count,
            false,
            false);

        applicationSender
            .SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender applicationSender,
        GetPostCommentLikeByIdApiRequest request,
        PostCommentLike postCommentLike,
        User user,
        CancellationToken cancellationToken)
    {
        var response = new GetPostCommentLikeByIdQueryResponse(
            new(postCommentLike.Id,
                postCommentLike.CommentId,
                new(
                    user.Id,
                    user.Name,
                    user.ProfileImage)));

        applicationSender
            .SendAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupAddCommandRequest(
        this IApplicationSender applicationSender,
        AddPostCommentLikeApiRequest request,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var response = new AddPostCommentLikeCommandResponse(postCommentLike.Id, postCommentLike.CommentId, postCommentLike.UserId, postCommentLike.CreatedAt, postCommentLike.UpdatedAt);

        applicationSender
            .SendAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }
}
