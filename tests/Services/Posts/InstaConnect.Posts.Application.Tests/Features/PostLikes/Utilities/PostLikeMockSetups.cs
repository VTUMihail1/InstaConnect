using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Infrastructure.Helpers;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
public static class PostLikeMockSetups
{
    public static void SetupGetAllQuery(
        this IPostLikeService postLikeService,
        GetAllPostLikesQueryRequest request,
        ICollection<PostLike> postLikes,
        CommonIncludeQuery<PostLikeIncludeProperty> include,
        CancellationToken cancellationToken)
    {
        var paginator = PaginatorFactory.Create();
        var filteredPostLikes = postLikes.Filter(a => a.MatchesFilter(request), request);

        var response = new PostLikeCollection(
            filteredPostLikes,
            request.Page,
            request.PageSize,
            postLikes.Count,
            paginator.HasNextPage(request.Page, request.PageSize, postLikes.Count),
            paginator.HasPreviousPage(request.Page));

        postLikeService
            .GetAllAsync(PostLikeMatcher.IsGetAllPostLikesQuery(request, include), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQuery(
        this IPostLikeService postLikeService,
        GetPostLikeByIdQueryRequest request,
        PostLike postLike,
        CommonIncludeQuery<PostLikeIncludeProperty> include,
        CancellationToken cancellationToken)
    {
        postLikeService
            .GetByIdAsync(PostLikeMatcher.IsGetPostLikeByIdQuery(request, include), cancellationToken)
            .ReturnsResponse(postLike);
    }

    public static void SetupAddCommand(
        this IPostLikeService postLikeService,
        AddPostLikeCommandRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        postLikeService
            .AddAsync(PostLikeMatcher.IsAddPostLikeCommand(request), cancellationToken)
            .ReturnsResponse(postLike);
    }
}
