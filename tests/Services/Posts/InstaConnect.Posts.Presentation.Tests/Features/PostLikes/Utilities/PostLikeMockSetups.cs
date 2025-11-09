namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
public static class PostLikeMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender applicationSender,
        GetAllPostLikesApiRequest request,
        PostLike postLike,
        User user,
        CancellationToken cancellationToken)
    {

        var postLikeQueryResponse = new PostLikeQueryResponse(
            postLike.Id,
            new(
                user.Id,
                user.Name,
                user.ProfileImage));
        var postLikeQueryResponses = new List<PostLikeQueryResponse>() { postLikeQueryResponse };

        var response = new GetAllPostLikesQueryResponse(
            postLikeQueryResponses,
            request.Pagination.Page,
            request.Pagination.PageSize,
            postLikeQueryResponses.Count,
            false,
            false);

        applicationSender
            .SendAsync(PostLikeMatcher.IsGetAllPostLikesQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender applicationSender,
        GetPostLikeByIdApiRequest request,
        PostLike postLike,
        User user,
        CancellationToken cancellationToken)
    {
        var response = new GetPostLikeByIdQueryResponse(
            new(
                postLike.Id,
                new(
                    user.Id,
                    user.Name,
                    user.ProfileImage)));

        applicationSender
            .SendAsync(PostLikeMatcher.IsGetPostLikeByIdQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupAddCommandRequest(
        this IApplicationSender applicationSender,
        AddPostLikeApiRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var response = new AddPostLikeCommandResponse(postLike.Id, postLike.UserId, postLike.CreatedAt, postLike.UpdatedAt);

        applicationSender
            .SendAsync(PostLikeMatcher.IsAddPostLikeCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }
}
