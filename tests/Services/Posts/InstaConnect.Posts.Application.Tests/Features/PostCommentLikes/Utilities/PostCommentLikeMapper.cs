using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeMapper
{
    internal static PostCommentLikeId ToIdResponse(
        this PostCommentLike postCommentLike)
    {
        return postCommentLike.Id;
    }

    internal static PostCommentLikeResponse ToFullResponse<TRequest>(
        this PostCommentLike postCommentLike,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return new(postCommentLike.Id,
                   postCommentLike.User?.ToFullResponse(),
                   postCommentLike.PostComment?.ToFullResponse(request),
                   postCommentLike.CreatedAtUtc);
    }

    internal static PostCommentLikeCollectionResponse ToResponseWithoutUser<TRequest>(
        this ICollection<PostCommentLike> postCommentLikes,
        Func<PostCommentLike, TRequest, bool> filter,
        Func<PostCommentLike, TRequest, PostCommentLikeResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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

    internal static PostCommentLikeResponse ToResponseWithoutUser<TRequest>(
        this PostCommentLike postCommentLike,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return new(postCommentLike.Id,
                   null,
                   postCommentLike.PostComment?.ToFullResponse(request),
                   postCommentLike.CreatedAtUtc);
    }

    internal static PostCommentLikeCollectionResponse ToResponseWithoutPostComment<TRequest>(
        this ICollection<PostCommentLike> postCommentLikes,
        Func<PostCommentLike, TRequest, bool> filter,
        Func<PostCommentLike, TRequest, PostCommentLikeResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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

    internal static PostCommentLikeResponse ToResponseWithoutPostComment<TRequest>(
        this PostCommentLike postCommentLike,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return new(postCommentLike.Id,
                   postCommentLike.User?.ToFullResponse(),
                   null,
                   postCommentLike.CreatedAtUtc);
    }

    public static PostCommentLikeId ToResponse(
        this PostCommentLike postCommentLike,
        AddPostCommentLikeCommandRequest request)
    {
        return postCommentLike.ToIdResponse();
    }

    public static PostCommentLikeResponse ToResponse(
        this PostCommentLike postCommentLike,
        GetPostCommentLikeByIdQueryRequest request)
    {
        return postCommentLike.ToFullResponse(request);
    }

    public static PostCommentLikeCollectionResponse ToResponse(
        this ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesQueryRequest request)
    {
        return postCommentLikes.ToResponseWithoutUser(
            (postCommentLike, request) => postCommentLike.MatchesFilter(request),
            (postCommentLike, request) => postCommentLike.ToResponseWithoutPostComment(request),
            request);
    }

    public static PostCommentLikeCollectionResponse ToResponse(
        this ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesForUserQueryRequest request)
    {
        return postCommentLikes.ToResponseWithoutPostComment(
            (postCommentLike, request) => postCommentLike.MatchesFilter(request),
            (postCommentLike, request) => postCommentLike.ToResponseWithoutUser(request),
            request);
    }
}
