namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
public static class PostMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender applicationSender,
        GetAllPostsApiRequest request,
        Post post,
        CancellationToken cancellationToken)
    {

        var postQueryResponse = new PostQueryResponse(
            post.Id.Id,
            post.Title,
            post.Content,
            new(
                post.User!.Id.Id,
                post.User.Name.Value,
                post.User.ProfileImage?.Url),
            post.CreatedAtUtc,
            post.UpdatedAtUtc);

        var postQueryResponses = new List<PostQueryResponse>() { postQueryResponse };
        var postQueryCollectionResponses = new PostCollectionQueryResponse(
            postQueryResponses,
            request.Page,
            request.PageSize,
            postQueryResponses.Count,
            false,
            false);

        var response = new GetAllPostsQueryResponse(postQueryCollectionResponses);

        applicationSender
            .SendAsync(PostMatcher.IsGetAllPostsQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender applicationSender,
        GetPostByIdApiRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        var response = new GetPostByIdQueryResponse(
            new(
                post.Id.Id,
                post.Title,
                post.Content,
                new(
                    post.User!.Id.Id,
                    post.User.Name.Value,
                    post.User.ProfileImage?.Url),
                post.CreatedAtUtc,
                post.UpdatedAtUtc));

        applicationSender
            .SendAsync(PostMatcher.IsGetPostByIdQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupAddCommandRequest(
        this IApplicationSender applicationSender,
        AddPostApiRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        var response = new AddPostCommandResponse(new(post.Id.Id));

        applicationSender
            .SendAsync(PostMatcher.IsAddPostCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupUpdateCommandRequest(
        this IApplicationSender applicationSender,
        UpdatePostApiRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        var response = new UpdatePostCommandResponse(new(post.Id.Id));

        applicationSender
            .SendAsync(PostMatcher.IsUpdatePostCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }
}
