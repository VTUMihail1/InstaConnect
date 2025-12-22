using InstaConnect.Common.Infrastructure.Helpers;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender applicationSender,
        GetAllPostCommentLikesApiRequest request,
        ICollection<PostCommentLike> postCommentLikes,
        CancellationToken cancellationToken)
    {
        var paginator = PaginatorFactory.Create();
        var offset = paginator.GetOffset(request.Page, request.PageSize);
        var postCommentLikeQueryResponses = postCommentLikes
            .Where(a => a.MatchesFilter(request))
            .Select(postComment => new PostCommentLikeQueryResponse(
                                       postComment.Id.CommentId.Id.Id,
                                       postComment.Id.CommentId.CommentId,
                                       new(
                                           postComment.User!.Id.Id,
                                           postComment.User.Name.Value,
                                           postComment.User.ProfileImage?.Url),
                                       postComment.CreatedAtUtc))
            .OrderBy(a => a.CreatedAtUtc)
            .Skip(offset)
            .Take(request.PageSize)
            .ToList();

        var postCommentLikeCollectionQueryResponse = new PostCommentLikeCollectionQueryResponse(
            postCommentLikeQueryResponses,
            request.Page,
            request.PageSize,
            postCommentLikes.Count,
            paginator.HasNextPage(request.Page, request.PageSize, postCommentLikes.Count),
            paginator.HasPreviousPage(request.Page));

        var response = new GetAllPostCommentLikesQueryResponse(postCommentLikeCollectionQueryResponse);

        applicationSender
            .SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender applicationSender,
        GetPostCommentLikeByIdApiRequest request,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var response = new GetPostCommentLikeByIdQueryResponse(
            new(
                postCommentLike.Id.CommentId.Id.Id,
                postCommentLike.Id.CommentId.CommentId,
                new(
                    postCommentLike.User!.Id.Id,
                    postCommentLike.User.Name.Value,
                    postCommentLike.User.ProfileImage?.Url),
                postCommentLike.CreatedAtUtc));

        applicationSender
            .SendAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupAddCommandRequest(
        this IApplicationSender applicationSender,
        AddPostCommentLikeApiRequest request,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var response = new AddPostCommentLikeCommandResponse(new(postCommentLike.Id.CommentId.Id.Id, postCommentLike.Id.CommentId.CommentId, postCommentLike.Id.UserId.Id));

        applicationSender
            .SendAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }
}
