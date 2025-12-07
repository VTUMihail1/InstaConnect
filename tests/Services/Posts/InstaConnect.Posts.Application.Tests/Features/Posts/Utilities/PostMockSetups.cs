namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
public static class PostMockSetups
{
    public static void SetupGetAllQuery(
        this IPostService postService,
        GetAllPostsQueryRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        var posts = new List<Post>() { post };
        var response = new PostCollection(
            posts,
            request.Page,
            request.PageSize,
            posts.Count,
            false,
            false);

        postService
            .GetAllAsync(PostMatcher.IsGetAllPostsQuery(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQuery(
        this IPostService postService,
        GetPostByIdQueryRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        postService
            .GetByIdAsync(PostMatcher.IsGetPostByIdQuery(request), cancellationToken)
            .ReturnsResponse(post);
    }

    public static void SetupAddCommand(
        this IPostService postService,
        AddPostCommandRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        postService
            .AddAsync(PostMatcher.IsAddPostCommand(request), cancellationToken)
            .ReturnsResponse(post);
    }

    public static void SetupUpdateCommand(
        this IPostService postService,
        UpdatePostCommandRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        postService
            .UpdateAsync(PostMatcher.IsUpdatePostCommand(request), cancellationToken)
            .ReturnsResponse(post);
    }
}
