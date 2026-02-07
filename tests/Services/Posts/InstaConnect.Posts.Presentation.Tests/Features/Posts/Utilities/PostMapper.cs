using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Features.Users.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
public static class PostMapper
{
    internal static PostIdCommandResponse ToIdResponse(
        this Post post)
    {
        return new(post.Id.Id);
    }

    internal static PostQueryResponse ToFullResponse<TRequest>(
        this Post post,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return new(post.Id.Id,
                   post.UserId.Id,
                   post.Title,
                   post.Content,
                   post.User?.ToFullResponse(),
                   post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                   post.CreatedAtUtc,
                   post.UpdatedAtUtc);
    }

    internal static PostCollectionQueryResponse ToFullResponse<TRequest>(
        this ICollection<Post> posts,
        User user,
        Func<Post, TRequest, bool> filter,
        Func<Post, TRequest, PostQueryResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        var paginator = new Paginator();

        return new(user.ToFullResponse(),
                    posts.Filter(post => filter(post, request), request, post => transform(post, request)),
                    request.Page,
                    request.PageSize,
                    posts.Count,
                    paginator.HasNextPage(request.Page, request.PageSize, posts.Count),
                    paginator.HasPreviousPage(request.Page));
    }

    internal static PostCollectionQueryResponse ToResponseWithoutUser<TRequest>(
        this ICollection<Post> posts,
        Func<Post, TRequest, bool> filter,
        Func<Post, TRequest, PostQueryResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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

    internal static PostQueryResponse ToResponseWithoutUser<TRequest>(
        this Post post,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return new(post.Id.Id,
                   post.UserId.Id,
                   post.Title,
                   post.Content,
                   null,
                   post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                   post.CreatedAtUtc,
                   post.UpdatedAtUtc);
    }

    public static AddPostCommandResponse ToResponse(
        this Post post,
        AddPostApiRequest request)
    {
        return new(post.ToIdResponse());
    }

    public static UpdatePostCommandResponse ToResponse(
        this Post post,
        UpdatePostApiRequest request)
    {
        return new(post.ToIdResponse());
    }

    public static GetPostByIdQueryResponse ToResponse(
        this Post post,
        GetPostByIdApiRequest request)
    {
        return new(post.ToFullResponse(request));
    }

    public static GetAllPostsQueryResponse ToResponse(
        this ICollection<Post> posts,
        GetAllPostsApiRequest request)
    {
        return new(posts.ToResponseWithoutUser((post, request) => post.MatchesFilter(request),
                                               (post, request) => post.ToFullResponse(request),
                                               request));
    }

    public static GetAllPostsForUserQueryResponse ToResponse(
        this ICollection<Post> posts,
        User user,
        GetAllPostsForUserApiRequest request)
    {
        return new(posts.ToFullResponse(user,
                                        (post, request) => post.MatchesFilter(request),
                                        (post, request) => post.ToResponseWithoutUser(request),
                                        request));
    }
}
