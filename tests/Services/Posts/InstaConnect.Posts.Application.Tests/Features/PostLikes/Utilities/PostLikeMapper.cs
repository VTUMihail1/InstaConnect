using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
public static class PostLikeMapper
{
    internal static PostLikeId ToIdResponse(
        this PostLike postLike)
    {
        return postLike.Id;
    }

    internal static PostLikeResponse ToFullResponse<TRequest>(
        this PostLike postLike,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return new(postLike.Id,
                   postLike.User?.ToFullResponse(),
                   postLike.Post?.ToFullResponse(request),
                   postLike.CreatedAtUtc);
    }

    internal static PostLikeCollectionResponse ToResponseWithoutUser<TRequest>(
        this ICollection<PostLike> postLikes,
        Func<PostLike, TRequest, bool> filter,
        Func<PostLike, TRequest, PostLikeResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        var paginator = new Paginator();
        var postLike = postLikes.FirstOrDefault();

        return new(postLike?.Post?.ToFullResponse(request),
                   null,
                   postLikes.Filter(postLike => filter(postLike, request), request, postLike => transform(postLike, request)),
                   request.Page,
                   request.PageSize,
                   postLikes.Count,
                   paginator.HasNextPage(request.Page, request.PageSize, postLikes.Count),
                   paginator.HasPreviousPage(request.Page));
    }

    internal static PostLikeResponse ToResponseWithoutUser<TRequest>(
        this PostLike postLike,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return new(postLike.Id,
                   null,
                   postLike.Post?.ToFullResponse(request),
                   postLike.CreatedAtUtc);
    }

    internal static PostLikeCollectionResponse ToResponseWithoutPost<TRequest>(
        this ICollection<PostLike> postLikes,
        Func<PostLike, TRequest, bool> filter,
        Func<PostLike, TRequest, PostLikeResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        var paginator = new Paginator();
        var postLike = postLikes.FirstOrDefault();

        return new(null,
                   postLike?.User?.ToFullResponse(),
                   postLikes.Filter(postLike => filter(postLike, request), request, postLike => transform(postLike, request)),
                   request.Page,
                   request.PageSize,
                   postLikes.Count,
                   paginator.HasNextPage(request.Page, request.PageSize, postLikes.Count),
                   paginator.HasPreviousPage(request.Page));
    }

    internal static PostLikeResponse ToResponseWithoutPost<TRequest>(
        this PostLike postLike,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return new(postLike.Id,
                   postLike.User?.ToFullResponse(),
                   null,
                   postLike.CreatedAtUtc);
    }

    public static PostLikeId ToResponse(
        this PostLike postLike,
        AddPostLikeCommandRequest request)
    {
        return postLike.ToIdResponse();
    }

    public static PostLikeResponse ToResponse(
        this PostLike postLike,
        GetPostLikeByIdQueryRequest request)
    {
        return postLike.ToFullResponse(request);
    }

    public static PostLikeCollectionResponse ToResponse(
        this ICollection<PostLike> postLikes,
        GetAllPostLikesQueryRequest request)
    {
        return postLikes.ToResponseWithoutUser(
            (postLike, request) => postLike.MatchesFilter(request),
            (postLike, request) => postLike.ToResponseWithoutPost(request),
            request);
    }

    public static PostLikeCollectionResponse ToResponse(
        this ICollection<PostLike> postLikes,
        GetAllPostLikesForUserQueryRequest request)
    {
        return postLikes.ToResponseWithoutPost(
            (postLike, request) => postLike.MatchesFilter(request),
            (postLike, request) => postLike.ToResponseWithoutUser(request),
            request);
    }
}
