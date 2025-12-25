using InstaConnect.Common.Infrastructure.Helpers;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
public static class PostMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender applicationSender,
        GetAllPostsApiRequest request,
        ICollection<Post> posts,
        CancellationToken cancellationToken)
    {
        var paginator = PaginatorFactory.Create();
        var filteredPosts = posts.Filter(
            a => a.MatchesFilter(request), request, p => new PostQueryResponse(
                     p.Id.Id,
                     p.Title,
                     p.Content,
                     new(
                         p.User!.Id.Id,
                         p.User.Name.Value,
                         p.User.ProfileImage?.Url),
                     p.CreatedAtUtc,
                     p.UpdatedAtUtc));

        var postResponse = new PostCollectionQueryResponse(
            filteredPosts,
            request.Page,
            request.PageSize,
            posts.Count,
            paginator.HasNextPage(request.Page, request.PageSize, posts.Count),
            paginator.HasPreviousPage(request.Page));

        var response = new GetAllPostsQueryResponse(postResponse);

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
