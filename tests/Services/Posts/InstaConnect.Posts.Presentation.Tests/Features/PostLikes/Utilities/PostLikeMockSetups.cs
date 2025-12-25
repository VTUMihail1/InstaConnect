using InstaConnect.Common.Infrastructure.Helpers;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
public static class PostLikeMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender applicationSender,
        GetAllPostLikesApiRequest request,
        ICollection<PostLike> postLikes,
        CancellationToken cancellationToken)
    {
        var paginator = PaginatorFactory.Create();
        var filteredPostLikes = postLikes.Filter(
            a => a.MatchesFilter(request), request, p => new PostLikeQueryResponse(
                p.Id.Id.Id,
                new(
                    p.User!.Id.Id,
                    p.User.Name.Value,
                    p.User.ProfileImage?.Url),
                p.CreatedAtUtc));

        var postLikeResponse = new PostLikeCollectionQueryResponse(
            filteredPostLikes,
            request.Page,
            request.PageSize,
            postLikes.Count,
            paginator.HasNextPage(request.Page, request.PageSize, postLikes.Count),
            paginator.HasPreviousPage(request.Page));

        var response = new GetAllPostLikesQueryResponse(postLikeResponse);

        applicationSender
            .SendAsync(PostLikeMatcher.IsGetAllPostLikesQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender applicationSender,
        GetPostLikeByIdApiRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var response = new GetPostLikeByIdQueryResponse(
            new(
                postLike.Id.Id.Id,
                new(
                    postLike.User!.Id.Id,
                    postLike.User.Name.Value,
                    postLike.User.ProfileImage?.Url),
                postLike.CreatedAtUtc));

        applicationSender
            .SendAsync(PostLikeMatcher.IsGetPostLikeByIdQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupAddCommandRequest(
        this IApplicationSender applicationSender,
        AddPostLikeApiRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var response = new AddPostLikeCommandResponse(new(postLike.Id.Id.Id, postLike.Id.UserId.Id));

        applicationSender
            .SendAsync(PostLikeMatcher.IsAddPostLikeCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }
}
