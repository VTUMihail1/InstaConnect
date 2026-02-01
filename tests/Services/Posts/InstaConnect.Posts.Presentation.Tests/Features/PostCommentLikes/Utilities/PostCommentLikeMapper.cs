using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Users.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMapper
{
    internal static PostCommentLikeIdCommandResponse ToIdResponse(
        this PostCommentLike postCommentLike)
    {
        return new(postCommentLike.Id.CommentId.Id.Id, postCommentLike.Id.CommentId.CommentId, postCommentLike.Id.UserId.Id);
    }

    internal static PostCommentLikeQueryResponse ToFullResponse<TRequest>(
        this PostCommentLike postCommentLike,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return new(postCommentLike.Id.CommentId.Id.Id,
                   postCommentLike.Id.CommentId.CommentId,
                   postCommentLike.Id.UserId.Id,
                   postCommentLike.User?.ToFullResponse(),
                   postCommentLike.PostComment?.ToFullResponse(request),
                   postCommentLike.CreatedAtUtc);
    }

    internal static PostCommentLikeCollectionQueryResponse ToResponseWithoutUser<TRequest>(
        this ICollection<PostCommentLike> postCommentLikes,
        Func<PostCommentLike, TRequest, bool> filter,
        Func<PostCommentLike, TRequest, PostCommentLikeQueryResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        var paginator = new Paginator();
        var postCommentLike = postCommentLikes.FirstOrDefault();

        return new(postCommentLike?.PostComment?.ToFullResponse(request),
                   null,
                   postCommentLikes.Filter(postCommentLike => filter(postCommentLike, request), request, postCommentLike => transform(postCommentLike, request)),
                   request.Page,
                   request.PageSize,
                   postCommentLikes.Count,
                   paginator.HasNextPage(request.Page, request.PageSize, postCommentLikes.Count),
                   paginator.HasPreviousPage(request.Page));
    }

    internal static PostCommentLikeQueryResponse ToResponseWithoutUser<TRequest>(
        this PostCommentLike postCommentLike,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return new(postCommentLike.Id.CommentId.Id.Id,
                   postCommentLike.Id.CommentId.CommentId,
                   postCommentLike.Id.UserId.Id,
                   null,
                   postCommentLike.PostComment?.ToFullResponse(request),
                   postCommentLike.CreatedAtUtc);
    }

    internal static PostCommentLikeCollectionQueryResponse ToResponseWithoutPostComment<TRequest>(
        this ICollection<PostCommentLike> postCommentLikes,
        Func<PostCommentLike, TRequest, bool> filter,
        Func<PostCommentLike, TRequest, PostCommentLikeQueryResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        var paginator = new Paginator();
        var postCommentLike = postCommentLikes.FirstOrDefault();

        return new(null,
                   postCommentLike?.User?.ToFullResponse(),
                   postCommentLikes.Filter(postCommentLike => filter(postCommentLike, request), request, postCommentLike => transform(postCommentLike, request)),
                   request.Page,
                   request.PageSize,
                   postCommentLikes.Count,
                   paginator.HasNextPage(request.Page, request.PageSize, postCommentLikes.Count),
                   paginator.HasPreviousPage(request.Page));
    }

    internal static PostCommentLikeQueryResponse ToResponseWithoutPostComment<TRequest>(
        this PostCommentLike postCommentLike,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return new(postCommentLike.Id.CommentId.Id.Id,
                   postCommentLike.Id.CommentId.CommentId,
                   postCommentLike.Id.UserId.Id,
                   postCommentLike.User?.ToFullResponse(),
                   null,
                   postCommentLike.CreatedAtUtc);
    }

    public static AddPostCommentLikeCommandResponse ToResponse(
        this PostCommentLike postCommentLike,
        AddPostCommentLikeApiRequest request)
    {
        return new(postCommentLike.ToIdResponse());
    }

    public static GetPostCommentLikeByIdQueryResponse ToResponse(
        this PostCommentLike postCommentLike,
        GetPostCommentLikeByIdApiRequest request)
    {
        return new(postCommentLike.ToFullResponse(request));
    }

    public static GetAllPostCommentLikesQueryResponse ToResponse(
        this ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesApiRequest request)
    {
        return new(postCommentLikes.ToResponseWithoutUser((postCommentLike, request) => postCommentLike.MatchesFilter(request),
                                                   (postCommentLike, request) => postCommentLike.ToResponseWithoutPostComment(request),
                                                   request));
    }

    public static GetAllPostCommentLikesForUserQueryResponse ToResponse(
        this ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesForUserApiRequest request)
    {
        return new(postCommentLikes.ToResponseWithoutPostComment((postCommentLike, request) => postCommentLike.MatchesFilter(request),
                                                   (postCommentLike, request) => postCommentLike.ToResponseWithoutUser(request),
                                                   request));
    }
}
