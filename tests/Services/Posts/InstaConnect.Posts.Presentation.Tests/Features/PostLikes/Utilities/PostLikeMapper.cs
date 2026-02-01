using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Features.Users.Models;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
public static class PostLikeMapper
{
    internal static PostLikeIdCommandResponse ToIdResponse(
        this PostLike postLike)
    {
        return new(postLike.Id.Id.Id, postLike.Id.UserId.Id);
    }

    internal static PostLikeQueryResponse ToFullResponse<TRequest>(
        this PostLike postLike,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return new(postLike.Id.Id.Id,
                   postLike.Id.UserId.Id,
                   postLike.User?.ToFullResponse(),
                   postLike.Post?.ToFullResponse(request),
                   postLike.CreatedAtUtc);
    }

    internal static PostLikeCollectionQueryResponse ToResponseWithoutUser<TRequest>(
        this ICollection<PostLike> postLikes,
        Func<PostLike, TRequest, bool> filter,
        Func<PostLike, TRequest, PostLikeQueryResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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

    internal static PostLikeQueryResponse ToResponseWithoutUser<TRequest>(
        this PostLike postLike,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return new(postLike.Id.Id.Id,
                   postLike.Id.UserId.Id,
                   null,
                   postLike.Post?.ToFullResponse(request),
                   postLike.CreatedAtUtc);
    }

    internal static PostLikeCollectionQueryResponse ToResponseWithoutPost<TRequest>(
        this ICollection<PostLike> postLikes,
        Func<PostLike, TRequest, bool> filter,
        Func<PostLike, TRequest, PostLikeQueryResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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

    internal static PostLikeQueryResponse ToResponseWithoutPost<TRequest>(
        this PostLike postLike,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return new(postLike.Id.Id.Id,
                   postLike.Id.UserId.Id,
                   postLike.User?.ToFullResponse(),
                   null,
                   postLike.CreatedAtUtc);
    }

    public static AddPostLikeCommandResponse ToResponse(
        this PostLike postLike,
        AddPostLikeApiRequest request)
    {
        return new(postLike.ToIdResponse());
    }

    public static GetPostLikeByIdQueryResponse ToResponse(
        this PostLike postLike,
        GetPostLikeByIdApiRequest request)
    {
        return new(postLike.ToFullResponse(request));
    }

    public static GetAllPostLikesQueryResponse ToResponse(
        this ICollection<PostLike> postLikes,
        GetAllPostLikesApiRequest request)
    {
        return new(postLikes.ToResponseWithoutUser((postLike, request) => postLike.MatchesFilter(request),
                                                   (postLike, request) => postLike.ToResponseWithoutPost(request),
                                                   request));
    }

    public static GetAllPostLikesForUserQueryResponse ToResponse(
        this ICollection<PostLike> postLikes,
        GetAllPostLikesForUserApiRequest request)
    {
        return new(postLikes.ToResponseWithoutPost((postLike, request) => postLike.MatchesFilter(request),
                                                   (postLike, request) => postLike.ToResponseWithoutUser(request),
                                                   request));
    }
}
