namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender applicationSender,
        GetAllPostCommentLikesApiRequest request,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {

        var postCommentLikeQueryResponse = new PostCommentLikeQueryResponse(
            postCommentLike.Id.CommentId.Id.Id,
            postCommentLike.Id.CommentId.CommentId,
            new(
                postCommentLike.User!.Id.Id,
                postCommentLike.User.Name.Value,
                postCommentLike.User.ProfileImage?.Url),
            postCommentLike.CreatedAtUtc);
        var postCommentLikeQueryResponses = new List<PostCommentLikeQueryResponse>() { postCommentLikeQueryResponse };
        var postCommentLikeCollectionQueryResponse = new PostCommentLikeCollectionQueryResponse(
            postCommentLikeQueryResponses,
            request.Page,
            request.PageSize,
            postCommentLikeQueryResponses.Count,
            false,
            false);

        var response = new GetAllPostCommentLikesQueryResponse(postCommentLikeCollectionQueryResponse);

        applicationSender
            .SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender applicationSender,
        GetPostCommentLikeByIdApiRequest request,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var response = new GetPostCommentLikeByIdQueryResponse(
            new(
                postCommentLike.Id.CommentId.Id.Id,
                postCommentLike.Id.CommentId.CommentId,
                new(
                    postCommentLike.User!.Id.Id,
                    postCommentLike.User.Name.Value,
                    postCommentLike.User.ProfileImage?.Url),
                postCommentLike.CreatedAtUtc));

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
        var response = new AddPostCommentLikeCommandResponse(new(postCommentLike.Id.CommentId.Id.Id, postCommentLike.Id.CommentId.CommentId, postCommentLike.Id.UserId.Id));

        applicationSender
            .SendAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }
}
