namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
public static class PostMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender applicationSender,
        GetAllPostsApiRequest request,
        Post post,
        User user,
        CancellationToken cancellationToken)
    {

        var postQueryResponse = new PostQueryResponse(
            post.Id,
            post.Title,
            post.Content,
            new(
                user.Id,
                user.Name,
                user.ProfileImage));
        var postQueryResponses = new List<PostQueryResponse>() { postQueryResponse };

        var response = new GetAllPostsQueryResponse(
            postQueryResponses,
            request.Pagination.Page,
            request.Pagination.PageSize,
            postQueryResponses.Count,
            false,
            false);

        applicationSender
            .SendAsync(PostMatcher.IsGetAllPostsQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender applicationSender,
        GetPostByIdApiRequest request,
        Post post,
        User user,
        CancellationToken cancellationToken)
    {
        var response = new GetPostByIdQueryResponse(
            new(
                post.Id,
                post.Title,
                post.Content,
                new(
                    user.Id,
                    user.Name,
                    user.ProfileImage)));

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
        var response = new AddPostCommandResponse(post.Id, post.CreatedAtUtc, post.UpdatedAtUtc);

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
        var response = new UpdatePostCommandResponse(post.Id, post.CreatedAtUtc, post.UpdatedAtUtc);

        applicationSender
            .SendAsync(PostMatcher.IsUpdatePostCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }
}
