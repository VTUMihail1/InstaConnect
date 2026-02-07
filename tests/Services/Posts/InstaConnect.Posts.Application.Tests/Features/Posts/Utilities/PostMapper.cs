using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
public static class PostMapper
{
    internal static PostId ToIdResponse(
        this Post post)
    {
        return post.Id;
    }

    internal static PostResponse ToFullResponse<TRequest>(
        this Post post,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return new(post.Id,
                   post.UserId,
                   post.Title,
                   post.Content,
                   post.User?.ToFullResponse(),
                   post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                   post.CreatedAtUtc,
                   post.UpdatedAtUtc);
    }

    internal static PostCollectionResponse ToFullResponse<TRequest>(
        this ICollection<Post> posts,
        User user,
        Func<Post, TRequest, bool> filter,
        Func<Post, TRequest, PostResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        var paginator = new Paginator();

        return new (user.ToFullResponse(),
                    posts.Filter(post => filter(post, request), request, post => transform(post, request)),
                    request.Page,
                    request.PageSize,
                    posts.Count,
                    paginator.HasNextPage(request.Page, request.PageSize, posts.Count),
                    paginator.HasPreviousPage(request.Page));
    }

    internal static PostCollectionResponse ToResponseWithoutUser<TRequest>(
        this ICollection<Post> posts,
        Func<Post, TRequest, bool> filter,
        Func<Post, TRequest, PostResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        var paginator = new Paginator();

        return new(null,
                   posts.Filter(post => filter(post, request), request, post => transform(post, request)),
                   request.Page,
                   request.PageSize,
                   posts.Count,
                   paginator.HasNextPage(request.Page, request.PageSize, posts.Count),
                   paginator.HasPreviousPage(request.Page));
    }

    internal static PostResponse ToResponseWithoutUser<TRequest>(
        this Post post,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return new(post.Id,
                   post.UserId,
                   post.Title,
                   post.Content,
                   null,
                   post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                   post.CreatedAtUtc,
                   post.UpdatedAtUtc);
    }

    public static PostId ToResponse(
        this Post post,
        AddPostCommandRequest request)
    {
        return post.ToIdResponse();
    }

    public static PostId ToResponse(
        this Post post,
        UpdatePostCommandRequest request)
    {
        return post.ToIdResponse();
    }

    public static PostResponse ToResponse(
        this Post post,
        GetPostByIdQueryRequest request)
    {
        return post.ToFullResponse(request);
    }

    public static PostCollectionResponse ToResponse(
        this ICollection<Post> posts,
        GetAllPostsQueryRequest request)
    {
        return posts.ToResponseWithoutUser(
            (post, request) => post.MatchesFilter(request),
            (post, request) => post.ToFullResponse(request),
            request);
    }

    public static PostCollectionResponse ToResponse(
        this ICollection<Post> posts,
        User user,
        GetAllPostsForUserQueryRequest request)
    {
        return posts.ToFullResponse(
            user,
            (post, request) => post.MatchesFilter(request),
            (post, request) => post.ToResponseWithoutUser(request),
            request);
    }
}
