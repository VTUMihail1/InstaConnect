using InstaConnect.Common.Infrastructure.Helpers;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
public static class PostCommentMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender applicationSender,
        GetAllPostCommentsApiRequest request,
        ICollection<PostComment> postComments,
        CancellationToken cancellationToken)
    {
        var paginator = PaginatorFactory.Create();
        var offset = paginator.GetOffset(request.Page, request.PageSize);
        var postCommentQueryResponses = postComments
            .Where(a => a.MatchesFilter(request))
            .Select(postComment => new PostCommentQueryResponse(
                                       postComment.Id.Id.Id,
                                       postComment.Id.CommentId,
                                       postComment.Content,
                                       new(
                                           postComment.User!.Id.Id,
                                           postComment.User.Name.Value,
                                           postComment.User.ProfileImage?.Url),
                                       postComment.CreatedAtUtc,
                                       postComment.UpdatedAtUtc))
            .OrderBy(a => a.CreatedAtUtc)
            .Skip(offset)
            .Take(request.PageSize)
            .ToList();

        var postCommentCollectionQueryResponse = new PostCommentCollectionQueryResponse(
            postCommentQueryResponses,
            request.Page,
            request.PageSize,
            postComments.Count,
            paginator.HasNextPage(request.Page, request.PageSize, postComments.Count),
            paginator.HasPreviousPage(request.Page));

        var response = new GetAllPostCommentsQueryResponse(postCommentCollectionQueryResponse);

        applicationSender
            .SendAsync(PostCommentMatcher.IsGetAllPostCommentsQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender applicationSender,
        GetPostCommentByIdApiRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var response = new GetPostCommentByIdQueryResponse(
            new(postComment.Id.Id.Id,
                postComment.Id.CommentId,
                postComment.Content,
                new(
                    postComment.User!.Id.Id,
                    postComment.User.Name.Value,
                    postComment.User.ProfileImage?.Url),
                postComment.CreatedAtUtc,
                postComment.UpdatedAtUtc));

        applicationSender
            .SendAsync(PostCommentMatcher.IsGetPostCommentByIdQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupAddCommandRequest(
        this IApplicationSender applicationSender,
        AddPostCommentApiRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var response = new AddPostCommentCommandResponse(new(postComment.Id.Id.Id, postComment.Id.CommentId));

        applicationSender
            .SendAsync(PostCommentMatcher.IsAddPostCommentCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupUpdateCommandRequest(
        this IApplicationSender applicationSender,
        UpdatePostCommentApiRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var response = new UpdatePostCommentCommandResponse(new(postComment.Id.Id.Id, postComment.Id.CommentId));

        applicationSender
            .SendAsync(PostCommentMatcher.IsUpdatePostCommentCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }
}
