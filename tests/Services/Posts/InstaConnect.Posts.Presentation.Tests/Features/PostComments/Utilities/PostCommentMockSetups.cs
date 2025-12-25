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
        var filteredPostComments = postComments.Filter(
            a => a.MatchesFilter(request), request, p => new PostCommentQueryResponse(
                                       p.Id.Id.Id,
                                       p.Id.CommentId,
                                       p.Content,
                                       new(
                                           p.User!.Id.Id,
                                           p.User.Name.Value,
                                           p.User.ProfileImage?.Url),
                                       p.CreatedAtUtc,
                                       p.UpdatedAtUtc));

        var postCommentResponse = new PostCommentCollectionQueryResponse(
            filteredPostComments,
            request.Page,
            request.PageSize,
            postComments.Count,
            paginator.HasNextPage(request.Page, request.PageSize, postComments.Count),
            paginator.HasPreviousPage(request.Page));

        var response = new GetAllPostCommentsQueryResponse(postCommentResponse);

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
