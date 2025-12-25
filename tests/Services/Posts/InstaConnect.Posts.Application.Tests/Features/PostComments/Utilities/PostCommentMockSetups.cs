using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Infrastructure.Helpers;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
public static class PostCommentMockSetups
{
    public static void SetupGetAllQuery(
        this IPostCommentService postCommentService,
        GetAllPostCommentsQueryRequest request,
        ICollection<PostComment> postComments,
        CommonIncludeQuery<PostCommentIncludeProperty> include,
        CancellationToken cancellationToken)
    {
        var paginator = PaginatorFactory.Create();
        var filteredPostComments = postComments.Filter(a => a.MatchesFilter(request), request);

        var response = new PostCommentCollection(
            filteredPostComments,
            request.Page,
            request.PageSize,
            postComments.Count,
            paginator.HasNextPage(request.Page, request.PageSize, postComments.Count),
            paginator.HasPreviousPage(request.Page));

        postCommentService
            .GetAllAsync(PostCommentMatcher.IsGetAllPostCommentsQuery(request, include), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQuery(
        this IPostCommentService postCommentService,
        GetPostCommentByIdQueryRequest request,
        PostComment postComment,
        CommonIncludeQuery<PostCommentIncludeProperty> include,
        CancellationToken cancellationToken)
    {
        postCommentService
            .GetByIdAsync(PostCommentMatcher.IsGetPostCommentByIdQuery(request, include), cancellationToken)
            .ReturnsResponse(postComment);
    }

    public static void SetupAddCommand(
        this IPostCommentService postCommentService,
        AddPostCommentCommandRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        postCommentService
            .AddAsync(PostCommentMatcher.IsAddPostCommentCommand(request), cancellationToken)
            .ReturnsResponse(postComment);
    }

    public static void SetupUpdateCommand(
        this IPostCommentService postCommentService,
        UpdatePostCommentCommandRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        postCommentService
            .UpdateAsync(PostCommentMatcher.IsUpdatePostCommentCommand(request), cancellationToken)
            .ReturnsResponse(postComment);
    }
}
