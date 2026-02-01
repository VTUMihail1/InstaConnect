namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
public static class PostMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender sender,
        GetAllPostsApiRequest request,
        ICollection<Post> posts,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostMatcher.IsGetAllPostsQueryRequest(request), cancellationToken)
            .ReturnsResponse(posts.ToResponse(request));
    }

    public static void SetupGetAllForUserQueryRequest(
        this IApplicationSender sender,
        GetAllPostsForUserApiRequest request,
        ICollection<Post> posts,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostMatcher.IsGetAllPostsForUserQueryRequest(request), cancellationToken)
            .ReturnsResponse(posts.ToResponse(request));
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender sender,
        GetPostByIdApiRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostMatcher.IsGetPostByIdQueryRequest(request), cancellationToken)
            .ReturnsResponse(post.ToResponse(request));
    }

    public static void SetupAddCommandRequest(
        this IApplicationSender sender,
        AddPostApiRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostMatcher.IsAddPostCommandRequest(request), cancellationToken)
            .ReturnsResponse(post.ToResponse(request));
    }

    public static void SetupUpdateCommandRequest(
        this IApplicationSender sender,
        UpdatePostApiRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostMatcher.IsUpdatePostCommandRequest(request), cancellationToken)
            .ReturnsResponse(post.ToResponse(request));
    }
}
