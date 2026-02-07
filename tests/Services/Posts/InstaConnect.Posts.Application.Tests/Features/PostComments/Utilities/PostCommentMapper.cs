using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
public static class PostCommentMapper
{
    internal static PostCommentId ToIdResponse(
        this PostComment postComment)
    {
        return postComment.Id;
    }

    internal static PostCommentResponse ToFullResponse<TRequest>(
        this PostComment postComment,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return new(postComment.Id,
                   postComment.UserId,
                   postComment.Content,
                   postComment.User?.ToFullResponse(),
                   postComment.Post?.ToFullResponse(request),
                   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                   postComment.CreatedAtUtc,
                   postComment.UpdatedAtUtc);
    }

    internal static PostCommentCollectionResponse ToResponseWithoutUser<TRequest>(
        this ICollection<PostComment> postComments,
        Post post,
        Func<PostComment, TRequest, bool> filter,
        Func<PostComment, TRequest, PostCommentResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        var paginator = new Paginator();

        return new(post.ToFullResponse(request),
                   null,
                   postComments.Filter(postComment => filter(postComment, request), request, postComment => transform(postComment, request)),
                   request.Page,
                   request.PageSize,
                   postComments.Count,
                   paginator.HasNextPage(request.Page, request.PageSize, postComments.Count),
                   paginator.HasPreviousPage(request.Page));
    }

    internal static PostCommentResponse ToResponseWithoutUser<TRequest>(
        this PostComment postComment,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return new(postComment.Id,
                   postComment.UserId,
                   postComment.Content,
                   null,
                   postComment.Post?.ToFullResponse(request),
                   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                   postComment.CreatedAtUtc,
                   postComment.UpdatedAtUtc);
    }

    internal static PostCommentCollectionResponse ToResponseWithoutPost<TRequest>(
        this ICollection<PostComment> postComments,
        User user,
        Func<PostComment, TRequest, bool> filter,
        Func<PostComment, TRequest, PostCommentResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        var paginator = new Paginator();

        return new(null,
                   user.ToFullResponse(),
                   postComments.Filter(postComment => filter(postComment, request), request, postComment => transform(postComment, request)),
                   request.Page,
                   request.PageSize,
                   postComments.Count,
                   paginator.HasNextPage(request.Page, request.PageSize, postComments.Count),
                   paginator.HasPreviousPage(request.Page));
    }

    internal static PostCommentResponse ToResponseWithoutPost<TRequest>(
        this PostComment postComment,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return new(postComment.Id,
                   postComment.UserId,
                   postComment.Content,
                   postComment.User?.ToFullResponse(),
                   null,
                   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                   postComment.CreatedAtUtc,
                   postComment.UpdatedAtUtc);
    }

    public static PostCommentId ToResponse(
        this PostComment postComment,
        AddPostCommentCommandRequest request)
    {
        return postComment.ToIdResponse();
    }

    public static PostCommentId ToResponse(
        this PostComment postComment,
        UpdatePostCommentCommandRequest request)
    {
        return postComment.ToIdResponse();
    }

    public static PostCommentResponse ToResponse(
        this PostComment postComment,
        GetPostCommentByIdQueryRequest request)
    {
        return postComment.ToFullResponse(request);
    }

    public static PostCommentCollectionResponse ToResponse(
        this ICollection<PostComment> postComments,
        Post post,
        GetAllPostCommentsQueryRequest request)
    {
        return postComments.ToResponseWithoutUser(post,
                                                  (postComment, request) => postComment.MatchesFilter(request),
                                                  (postComment, request) => postComment.ToResponseWithoutPost(request),
                                                  request);
    }

    public static PostCommentCollectionResponse ToResponse(
        this ICollection<PostComment> postComments,
        User user,
        GetAllPostCommentsForUserQueryRequest request)
    {
        return postComments.ToResponseWithoutPost(user,
                                                  (postComment, request) => postComment.MatchesFilter(request),
                                                  (postComment, request) => postComment.ToResponseWithoutUser(request),
                                                  request);
    }
}
