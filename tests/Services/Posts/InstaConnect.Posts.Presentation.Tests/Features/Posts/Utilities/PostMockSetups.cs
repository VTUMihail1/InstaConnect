using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Posts.Application.Features.PostLikes.Models;

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
        var offset = paginator.GetOffset(request.Page, request.PageSize);
        var postQueryResponses = posts
            .Where(a => a.MatchesFilter(request))
            .Select(p => new PostQueryResponse(
                     p.Id.Id,
                     p.Title,
                     p.Content,
                     new(
                         p.User!.Id.Id,
                         p.User.Name.Value,
                         p.User.ProfileImage?.Url),
                     p.CreatedAtUtc,
                     p.UpdatedAtUtc))
            .OrderBy(a => a.CreatedAtUtc)
            .Skip(offset)
            .Take(request.PageSize)
            .ToList();

        var postQueryCollectionResponses = new PostCollectionQueryResponse(
            postQueryResponses,
            request.Page,
            request.PageSize,
            posts.Count,
            paginator.HasNextPage(request.Page, request.PageSize, posts.Count),
            paginator.HasPreviousPage(request.Page));

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
