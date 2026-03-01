using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Features.Users.Models.Responses;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostEquals
{
    public static bool Matches(this GetAllPostsQueryRequest query, GetAllPostsApiRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostsQueryRequest, GetAllPostsApiRequest, PostsSortTerm>(request) &&
               query.MatchesPaginatable(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this GetAllPostsForUserQueryRequest query, GetAllPostsForUserApiRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostsForUserQueryRequest, GetAllPostsForUserApiRequest, PostsForUserSortTerm>(request) &&
               query.MatchesPaginatable(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this GetPostByIdQueryRequest query, GetPostByIdApiRequest request)
    {
        return query.Id == request.Id &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this AddPostCommandRequest command, AddPostApiRequest request)
    {
        return command.Title == request.Body.Title &&
               command.Content == request.Body.Content &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this UpdatePostCommandRequest command, UpdatePostApiRequest request)
    {
        return command.Id == request.Id &&
               command.Title == request.Body.Title &&
               command.Content == request.Body.Content &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this DeletePostCommandRequest command, DeletePostApiRequest request)
    {
        return command.Id == request.Id &&
               command.UserId == request.UserId;
    }

    public static bool Matches(
        this AddPostApiResponse response,
        Post post,
        AddPostApiRequest request)
    {
        return response.Id.Matches(post.Id);
    }

    public static bool Matches(
        this UpdatePostApiResponse response,
        Post post,
        UpdatePostApiRequest request)
    {
        return response.Id.Matches(post.Id);
    }

    public static bool Matches(this GetPostByIdApiResponse response, Post post, GetPostByIdApiRequest request)
    {
        return response.Post.MatchesFull(post, request);
    }

    public static bool Matches(
        this GetAllPostsApiResponse response,
        ICollection<Post> posts,
        GetAllPostsApiRequest request)
    {
        return response.PostCollection.MatchesWithoutUser(
                   (response, post) => response.MatchesFull(post, request),
                   post => post.MatchesFilter(request),
                   posts,
                   request);
    }

    public static bool Matches(
        this GetAllPostsApiResponse response,
        ICollection<Post> posts,
        GetAllPostsApiRequest request,
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
        this GetAllPostsForUserApiResponse response,
        User user,
        ICollection<Post> posts,
        GetAllPostsForUserApiRequest request)
    {
        return response.PostCollection.MatchesFull(
                   (response, post) => response.MatchesWithoutUser(post, request),
                   post => post.MatchesFilter(request),
                   user,
                   posts,
                   request);
    }

    public static bool Matches(
        this GetAllPostsForUserApiResponse response,
        User user,
        ICollection<Post> posts,
        GetAllPostsForUserApiRequest request,
        ISortEnumTermTransformer<Post> termTransformer)
    {
        return response.PostCollection.MatchesFull(
                   (response, post) => response.MatchesWithoutUser(post, request),
                   post => post.MatchesFilter(request),
                   user,
                   posts,
                   request,
                   termTransformer);
    }

    public static bool Matches(this Post post, AddPostApiRequest request)
    {
        return post.UserId.Matches(request.UserId) &&
               post.Title == request.Body.Title &&
               post.Content == request.Body.Content;
    }

    public static bool Matches(this Post post, UpdatePostApiRequest request)
    {
        return post.Id.Matches(request.Id) &&
               post.UserId.Matches(request.UserId) &&
               post.Title == request.Body.Title &&
               post.Content == request.Body.Content;
    }

    public static bool Matches(this PostIdApiResponse response, PostId id)
    {
        return id.Matches(response.Id);
    }

    public static bool MatchesFull<TRequest>(this PostApiResponse? response, Post? post, TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return response != null &&
               post != null &&
               post.Id.Matches(response.Id) &&
               post.UserId.Matches(response.UserId) &&
               post.Title == response.Title &&
               post.Content == response.Content &&
               response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
               post.CreatedAtUtc == response.CreatedAtUtc &&
               post.UpdatedAtUtc == response.UpdatedAtUtc &&
               response.User.MatchesFull(post.User);
    }

    public static bool MatchesFull<TRequest>(
        this PostCollectionApiResponse response,
        Func<PostApiResponse, Post, bool> matches,
        Func<Post, bool> matchesFilter,
        User user,
        ICollection<Post> posts,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        return response.MatchesCollectionResponse(posts.Count(matchesFilter), request) &&
               response.User.MatchesFull(user) &&
               response.Posts.MatchesCollection(posts,
                                                response => new(response.Id),
                                                post => post.Id,
                                                matches,
                                                request,
                                                matchesFilter);
    }

    public static bool MatchesFull<TRequest>(
        this PostCollectionApiResponse response,
        Func<PostApiResponse, Post, bool> matches,
        Func<Post, bool> matchesFilter,
        User user,
        ICollection<Post> posts,
        TRequest request,
        ISortEnumTermTransformer<Post> termTransformer)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        return response.MatchesCollectionResponse(posts.Count(matchesFilter), request) &&
               response.User.MatchesFull(user) &&
               response.Posts.MatchesSortedCollection(posts,
                                                      matches,
                                                      termTransformer,
                                                      request,
                                                      matchesFilter);
    }

    public static bool MatchesWithoutUser<TRequest>(this PostApiResponse? response, Post? post, TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return response != null &&
               post != null &&
               post.Id.Matches(response.Id) &&
               post.UserId.Matches(response.UserId) &&
               post.Title == response.Title &&
               post.Content == response.Content &&
               response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
               post.CreatedAtUtc == response.CreatedAtUtc &&
               post.UpdatedAtUtc == response.UpdatedAtUtc &&
               response.User == null;
    }

    public static bool MatchesWithoutUser<TRequest>(
        this PostCollectionApiResponse response,
        Func<PostApiResponse, Post, bool> matches,
        Func<Post, bool> matchesFilter,
        ICollection<Post> posts,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        return response.MatchesCollectionResponse(posts.Count(matchesFilter), request) &&
               response.User == null &&
               response.Posts.MatchesCollection(posts,
                                                response => new(response.Id),
                                                post => post.Id,
                                                matches,
                                                request,
                                                matchesFilter);
    }

    public static bool MatchesWithoutUser<TRequest>(
        this PostCollectionApiResponse response,
        Func<PostApiResponse, Post, bool> matches,
        Func<Post, bool> matchesFilter,
        ICollection<Post> posts,
        TRequest request,
        ISortEnumTermTransformer<Post> termTransformer)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        return response.MatchesCollectionResponse(posts.Count(matchesFilter), request) &&
               response.User == null &&
               response.Posts.MatchesSortedCollection(posts,
                                                      matches,
                                                      termTransformer,
                                                      request,
                                                      matchesFilter);
    }

    public static bool MatchesFilter(this GetAllPostsQueryRequest query, GetAllPostsApiRequest request)
    {
        return query.UserName == request.UserName &&
               query.Title == request.Title;
    }

    public static bool MatchesFilter(this Post post, GetAllPostsApiRequest request)
    {
        return post.User != null &&
               post.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName) &&
               post.Title.StartsWithOrdinalIgnoreCase(request.Title);
    }

    public static bool MatchesFilter(this GetAllPostsForUserQueryRequest query, GetAllPostsForUserApiRequest request)
    {
        return query.UserId == request.UserId &&
               query.Title == request.Title;
    }

    public static bool MatchesFilter(this Post post, GetAllPostsForUserApiRequest request)
    {
        return post.UserId.Id.StartsWithOrdinalIgnoreCase(request.UserId) &&
               post.Title.StartsWithOrdinalIgnoreCase(request.Title);
    }
}
