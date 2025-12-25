using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Infrastructure.Helpers;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeMockSetups
{
    public static void SetupGetAllQuery(
        this IPostCommentLikeService postCommentLikeService,
        GetAllPostCommentLikesQueryRequest request,
        ICollection<PostCommentLike> postCommentLikes,
        CommonIncludeQuery<PostCommentLikeIncludeProperty> include,
        CancellationToken cancellationToken)
    {
        var paginator = PaginatorFactory.Create();
        var filteredPostCommentLikes = postCommentLikes.Filter(a => a.MatchesFilter(request), request);

        var response = new PostCommentLikeCollection(
            filteredPostCommentLikes,
            request.Page,
            request.PageSize,
            postCommentLikes.Count,
            paginator.HasNextPage(request.Page, request.PageSize, postCommentLikes.Count),
            paginator.HasPreviousPage(request.Page));

        postCommentLikeService
            .GetAllAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQuery(request, include), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQuery(
        this IPostCommentLikeService postCommentLikeService,
        GetPostCommentLikeByIdQueryRequest request,
        PostCommentLike postCommentLike,
        CommonIncludeQuery<PostCommentLikeIncludeProperty> include,
        CancellationToken cancellationToken)
    {
        postCommentLikeService
            .GetByIdAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQuery(request, include), cancellationToken)
            .ReturnsResponse(postCommentLike);
    }

    public static void SetupAddCommand(
        this IPostCommentLikeService postCommentLikeService,
        AddPostCommentLikeCommandRequest request,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        postCommentLikeService
            .AddAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommand(request), cancellationToken)
            .ReturnsResponse(postCommentLike);
    }
}
