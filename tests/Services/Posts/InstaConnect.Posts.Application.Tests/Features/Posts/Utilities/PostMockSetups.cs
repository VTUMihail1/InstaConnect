using InstaConnect.Common.Infrastructure.Helpers;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
public static class PostMockSetups
{
    public static void SetupGetAllQuery(
        this IPostService postService,
        GetAllPostsQueryRequest request,
        ICollection<Post> posts,
        CommonIncludeQuery<PostIncludeProperty> include,
        CancellationToken cancellationToken)
    {
        var paginator = PaginatorFactory.Create();
        var offset = paginator.GetOffset(request.Page, request.PageSize);
        var postsPaginated = posts
            .Where(a => a.MatchesFilter(request))
            .OrderBy(a => a.CreatedAtUtc)
            .Skip(offset)
            .Take(request.PageSize)
            .ToList();

        var response = new PostCollection(
            postsPaginated,
            request.Page,
            request.PageSize,
            posts.Count,
            paginator.HasNextPage(request.Page, request.PageSize, posts.Count),
            paginator.HasPreviousPage(request.Page));

        postService
            .GetAllAsync(PostMatcher.IsGetAllPostsQuery(request, include), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQuery(
        this IPostService postService,
        GetPostByIdQueryRequest request,
        Post post,
        CommonIncludeQuery<PostIncludeProperty> include,
        CancellationToken cancellationToken)
    {
        postService
            .GetByIdAsync(PostMatcher.IsGetPostByIdQuery(request, include), cancellationToken)
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
