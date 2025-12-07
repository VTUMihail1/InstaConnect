namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
public static class PostLikeMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender applicationSender,
        GetAllPostLikesApiRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var postLikeQueryResponse = new PostLikeQueryResponse(
            postLike.Id.Id.Id,
                new(
                    postLike.User!.Id.Id,
                    postLike.User.Name.Value,
                    postLike.User.ProfileImage?.Url),
                postLike.CreatedAtUtc);

        var postLikeQueryResponses = new List<PostLikeQueryResponse>() { postLikeQueryResponse };

        var postLikeCollectionQueryResponse = new PostLikeCollectionQueryResponse(
            postLikeQueryResponses,
            request.Page,
            request.PageSize,
            postLikeQueryResponses.Count,
            false,
            false);

        var response = new GetAllPostLikesQueryResponse(postLikeCollectionQueryResponse);

        applicationSender
            .SendAsync(PostLikeMatcher.IsGetAllPostLikesQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender applicationSender,
        GetPostLikeByIdApiRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var response = new GetPostLikeByIdQueryResponse(
            new(
                postLike.Id.Id.Id,
                new(
                    postLike.User!.Id.Id,
                    postLike.User.Name.Value,
                    postLike.User.ProfileImage?.Url),
                postLike.CreatedAtUtc));

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
        var response = new AddPostLikeCommandResponse(new(postLike.Id.Id.Id, postLike.Id.UserId.Id));

        applicationSender
            .SendAsync(PostLikeMatcher.IsAddPostLikeCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }
}
