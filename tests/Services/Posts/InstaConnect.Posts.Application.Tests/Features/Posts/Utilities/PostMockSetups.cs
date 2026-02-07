using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
public static class PostMockSetups
{
    public static void SetupGetAllQuery(
        this IPostQueryService service,
        GetAllPostsQueryRequest request,
        ICollection<Post> posts,
        CancellationToken cancellationToken)
    {
        service
            .GetAllAsync(PostMatcher.IsGetAllPostsQuery(request), cancellationToken)
            .ReturnsResponse(posts.ToResponse(request));
    }

    public static void SetupGetAllForUserQuery(
        this IPostQueryService service,
        GetAllPostsForUserQueryRequest request,
        User user,
        ICollection<Post> posts,
        CancellationToken cancellationToken)
    {
        service
            .GetAllForUserAsync(PostMatcher.IsGetAllPostsForUserQuery(request), cancellationToken)
            .ReturnsResponse(posts.ToResponse(user, request));
    }

    public static void SetupGetByIdQuery(
        this IPostQueryService service,
        GetPostByIdQueryRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        service
            .GetByIdAsync(PostMatcher.IsGetPostByIdQuery(request), cancellationToken)
            .ReturnsResponse(post.ToResponse(request));
    }

    public static void SetupAddCommand(
        this IPostCommandService service,
        AddPostCommandRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        service
            .AddAsync(PostMatcher.IsAddPostCommand(request), cancellationToken)
            .ReturnsResponse(post.ToResponse(request));
    }

    public static void SetupUpdateCommand(
        this IPostCommandService service,
        UpdatePostCommandRequest request,
        Post post,
        CancellationToken cancellationToken)
    {
        service
            .UpdateAsync(PostMatcher.IsUpdatePostCommand(request), cancellationToken)
            .ReturnsResponse(post.ToResponse(request));
    }
}
