using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Features.Users.Models;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
public static class PostCommentMapper
{
    internal static PostCommentIdCommandResponse ToIdResponse(
        this PostComment postComment)
    {
        return new(postComment.Id.Id.Id, postComment.UserId.Id);
    }

    internal static PostCommentQueryResponse ToFullResponse<TRequest>(
        this PostComment postComment,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return new(postComment.Id.Id.Id,
                   postComment.Id.CommentId,
                   postComment.UserId.Id,
                   postComment.Content,
                   postComment.User?.ToFullResponse(),
                   postComment.Post?.ToFullResponse(request),
                   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                   postComment.CreatedAtUtc,
                   postComment.UpdatedAtUtc);
    }

    internal static PostCommentCollectionQueryResponse ToResponseWithoutUser<TRequest>(
        this ICollection<PostComment> postComments,
        Func<PostComment, TRequest, bool> filter,
        Func<PostComment, TRequest, PostCommentQueryResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        var paginator = new Paginator();
        var postComment = postComments.FirstOrDefault();

        return new(postComment?.Post?.ToFullResponse(request),
                   null,
                   postComments.Filter(postComment => filter(postComment, request), request, postComment => transform(postComment, request)),
                   request.Page,
                   request.PageSize,
                   postComments.Count,
                   paginator.HasNextPage(request.Page, request.PageSize, postComments.Count),
                   paginator.HasPreviousPage(request.Page));
    }

    internal static PostCommentQueryResponse ToResponseWithoutUser<TRequest>(
        this PostComment postComment,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return new(postComment.Id.Id.Id,
                   postComment.Id.CommentId,
                   postComment.UserId.Id,
                   postComment.Content,
                   null,
                   postComment.Post?.ToFullResponse(request),
                   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                   postComment.CreatedAtUtc,
                   postComment.UpdatedAtUtc);
    }

    internal static PostCommentCollectionQueryResponse ToResponseWithoutPost<TRequest>(
        this ICollection<PostComment> postComments,
        Func<PostComment, TRequest, bool> filter,
        Func<PostComment, TRequest, PostCommentQueryResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        var paginator = new Paginator();
        var postComment = postComments.FirstOrDefault();

        return new(null,
                   postComment?.User?.ToFullResponse(),
                   postComments.Filter(postComment => filter(postComment, request), request, postComment => transform(postComment, request)),
                   request.Page,
                   request.PageSize,
                   postComments.Count,
                   paginator.HasNextPage(request.Page, request.PageSize, postComments.Count),
                   paginator.HasPreviousPage(request.Page));
    }

    internal static PostCommentQueryResponse ToResponseWithoutPost<TRequest>(
        this PostComment postComment,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return new(postComment.Id.Id.Id,
                   postComment.Id.CommentId,
                   postComment.UserId.Id,
                   postComment.Content,
                   postComment.User?.ToFullResponse(),
                   null,
                   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                   postComment.CreatedAtUtc,
                   postComment.UpdatedAtUtc);
    }

    public static AddPostCommentCommandResponse ToResponse(
        this PostComment postComment,
        AddPostCommentApiRequest request)
    {
        return new(postComment.ToIdResponse());
    }

    public static UpdatePostCommentCommandResponse ToResponse(
        this PostComment postComment,
        UpdatePostCommentApiRequest request)
    {
        return new(postComment.ToIdResponse());
    }

    public static GetPostCommentByIdQueryResponse ToResponse(
        this PostComment postComment,
        GetPostCommentByIdApiRequest request)
    {
        return new(postComment.ToFullResponse(request));
    }

    public static GetAllPostCommentsQueryResponse ToResponse(
        this ICollection<PostComment> postComments,
        GetAllPostCommentsApiRequest request)
    {
        return new(postComments.ToResponseWithoutUser((postComment, request) => postComment.MatchesFilter(request),
                                                      (postComment, request) => postComment.ToResponseWithoutPost(request),
                                                      request));
    }

    public static GetAllPostCommentsForUserQueryResponse ToResponse(
        this ICollection<PostComment> postComments,
        GetAllPostCommentsForUserApiRequest request)
    {
        return new(postComments.ToResponseWithoutPost((postComment, request) => postComment.MatchesFilter(request),
                                                      (postComment, request) => postComment.ToResponseWithoutUser(request),
                                                      request));
    }
}
