using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostEquals
{
    public static bool Matches(this GetAllPostsQuery query, GetAllPostsQueryRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostsQuery, GetAllPostsQueryRequest, PostsSortTerm, PostsSortingQuery>(request) &&
               query.MatchesPaginatable<GetAllPostsQuery, GetAllPostsQueryRequest, PostsPaginationQuery>(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this GetAllPostsForUserQuery query, GetAllPostsForUserQueryRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostsForUserQuery, GetAllPostsForUserQueryRequest, PostsSortTerm, PostsSortingQuery>(request) &&
               query.MatchesPaginatable<GetAllPostsForUserQuery, GetAllPostsForUserQueryRequest, PostsPaginationQuery>(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this GetPostByIdQuery query, GetPostByIdQueryRequest request)
    {
        return query.Id.Matches(request.Id) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this AddPostCommand command, AddPostCommandRequest request)
    {
        return command.UserId.Matches(request.UserId) &&
               command.Title == request.Title &&
               command.Content == request.Content;
    }

    public static bool Matches(this UpdatePostCommand command, UpdatePostCommandRequest request)
    {
        return command.Id.Matches(request.Id) &&
               command.UserId.Matches(request.UserId) &&
               command.Title == request.Title &&
               command.Content == request.Content;
    }

    public static bool Matches(this DeletePostCommand command, DeletePostCommandRequest request)
    {
        return command.Id.Matches(request.Id) &&
               command.UserId.Matches(request.UserId);
    }

    public static bool Matches(this AddPostCommandResponse response, Post post, AddPostCommandRequest request)
    {
        return response.Id.Matches(post.Id);
    }

    public static bool Matches(this UpdatePostCommandResponse response, Post post, UpdatePostCommandRequest request)
    {
        return response.Id.Matches(post.Id);
    }

    public static bool Matches(this GetPostByIdQueryResponse response, Post post, GetPostByIdQueryRequest request)
    {
        return response.Post.MatchesFull(post, request);
    }

    public static bool Matches(
        this GetAllPostsQueryResponse response,
        ICollection<Post> posts,
        GetAllPostsQueryRequest request)
    {
        return response.PostCollection.MatchesWithoutUser(
                   (response, post) => response.MatchesFull(post, request),
                   post => post.MatchesFilter(request),
                   posts,
                   request);
    }

    public static bool Matches(
        this GetAllPostsQueryResponse response,
        ICollection<Post> posts,
        GetAllPostsQueryRequest request,
        ISortEnumTermTransformer<Post> termTransformer)
    {
        return response.PostCollection.MatchesWithoutUser(
                   (response, post) => response.MatchesFull(post, request),
                   post => post.MatchesFilter(request),
                   posts,
                   request,
                   termTransformer);
    }

    public static bool Matches(
        this GetAllPostsForUserQueryResponse response,
        ICollection<Post> posts,
        GetAllPostsForUserQueryRequest request)
    {
        return response.PostCollection.MatchesFull(
                   (response, post) => response.MatchesWithoutUser(post, request),
                   post => post.MatchesFilter(request),
                   posts,
                   request);
    }

    public static bool Matches(
        this GetAllPostsForUserQueryResponse response,
        ICollection<Post> posts,
        GetAllPostsForUserQueryRequest request,
        ISortEnumTermTransformer<Post> termTransformer)
    {
        return response.PostCollection.MatchesFull(
                   (response, post) => response.MatchesWithoutUser(post, request),
                   post => post.MatchesFilter(request),
                   posts,
                   request,
                   termTransformer);
    }

    public static bool Matches(this Post post, AddPostCommandRequest request)
    {
        return post.UserId.Matches(request.UserId) &&
               post.Title == request.Title &&
               post.Content == request.Content;
    }

    public static bool Matches(this Post post, UpdatePostCommandRequest request)
    {
        return post.Id.Matches(request.Id) &&
               post.UserId.Matches(request.UserId) &&
               post.Title == request.Title &&
               post.Content == request.Content;
    }

    public static bool Matches(this PostIdCommandResponse response, PostId id)
    {
        return id.Matches(response.Id);
    }

    public static bool MatchesFull<TRequest>(this PostQueryResponse? response, Post? post, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return response != null &&
               post != null &&
               post.Id.Matches(response.Id) &&
               post.Title == response.Title &&
               post.Content == response.Content &&
               response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
               post.CreatedAtUtc == response.CreatedAtUtc &&
               post.UpdatedAtUtc == response.UpdatedAtUtc &&
               response.User.MatchesFull(post.User);
    }

    public static bool MatchesFull<TRequest>(
        this PostCollectionQueryResponse response,
        Func<PostQueryResponse, Post, bool> matches,
        Func<Post, bool> matchesFilter,
        ICollection<Post> posts,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        var post = posts.FirstOrDefault();

        return response.MatchesCollectionResponse(posts.Count, request) &&
               response.User.MatchesFull(post?.User) &&
               response.Posts.MatchesCollection(posts,
                                                response => response.Id,
                                                post => post.Id.Id,
                                                matches,
                                                request,
                                                matchesFilter);
    }

    public static bool MatchesFull<TRequest>(
        this PostCollectionQueryResponse response,
        Func<PostQueryResponse, Post, bool> matches,
        Func<Post, bool> matchesFilter,
        ICollection<Post> posts,
        TRequest request,
        ISortEnumTermTransformer<Post> termTransformer)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        var post = posts.FirstOrDefault();

        return response.MatchesCollectionResponse(posts.Count, request) &&
               response.User.MatchesFull(post?.User) &&
               response.Posts.MatchesSortedCollection(posts,
                                                      matches,
                                                      termTransformer,
                                                      request,
                                                      matchesFilter);
    }

    public static bool MatchesWithoutUser<TRequest>(this PostQueryResponse? response, Post? post, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return response != null &&
               post != null &&
               post.Id.Matches(response.Id) &&
               post.Title == response.Title &&
               post.Content == response.Content &&
               response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
               post.CreatedAtUtc == response.CreatedAtUtc &&
               post.UpdatedAtUtc == response.UpdatedAtUtc &&
               response.User == null;
    }

    public static bool MatchesWithoutUser<TRequest>(
        this PostCollectionQueryResponse response,
        Func<PostQueryResponse, Post, bool> matches,
        Func<Post, bool> matchesFilter,
        ICollection<Post> posts,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        return response.MatchesCollectionResponse(posts.Count, request) &&
               response.User == null &&
               response.Posts.MatchesCollection(posts,
                                                response => response.Id,
                                                post => post.Id.Id,
                                                matches,
                                                request,
                                                matchesFilter);
    }

    public static bool MatchesWithoutUser<TRequest>(
        this PostCollectionQueryResponse response,
        Func<PostQueryResponse, Post, bool> matches,
        Func<Post, bool> matchesFilter,
        ICollection<Post> posts,
        TRequest request,
        ISortEnumTermTransformer<Post> termTransformer)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        return response.MatchesCollectionResponse(posts.Count, request) &&
               response.User == null &&
               response.Posts.MatchesSortedCollection(posts,
                                                      matches,
                                                      termTransformer,
                                                      request,
                                                      matchesFilter);
    }

    public static bool MatchesFilter(this GetAllPostsQuery query, GetAllPostsQueryRequest request)
    {
        return query.Filter.UserName.Matches(request.UserName) &&
               query.Filter.Title == request.Title;
    }

    public static bool MatchesFilter(this Post post, GetAllPostsQueryRequest request)
    {
        return post.User != null &&
               post.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName) &&
               post.Title.StartsWithOrdinalIgnoreCase(request.Title);
    }

    public static bool MatchesFilter(this GetAllPostsForUserQuery query, GetAllPostsForUserQueryRequest request)
    {
        return query.Filter.UserId.Matches(request.UserId) &&
               query.Filter.Title == request.Title;
    }

    public static bool MatchesFilter(this Post post, GetAllPostsForUserQueryRequest request)
    {
        return post.UserId.Id.StartsWithOrdinalIgnoreCase(request.UserId) &&
               post.Title.StartsWithOrdinalIgnoreCase(request.Title);
    }
}
