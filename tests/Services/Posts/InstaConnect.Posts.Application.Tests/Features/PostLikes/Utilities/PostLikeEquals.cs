using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
    public static bool Matches(this GetAllPostLikesQuery query, GetAllPostLikesQueryRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostLikesQuery, GetAllPostLikesQueryRequest, PostLikesSortTerm, PostLikesSortingQuery>(request) &&
               query.MatchesPaginatable<GetAllPostLikesQuery, GetAllPostLikesQueryRequest, PostLikesPaginationQuery>(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this GetAllPostLikesForUserQuery query, GetAllPostLikesForUserQueryRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostLikesForUserQuery, GetAllPostLikesForUserQueryRequest, PostLikesSortTerm, PostLikesSortingQuery>(request) &&
               query.MatchesPaginatable<GetAllPostLikesForUserQuery, GetAllPostLikesForUserQueryRequest, PostLikesPaginationQuery>(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this GetPostLikeByIdQuery query, GetPostLikeByIdQueryRequest request)
    {
        return query.Id.Matches(request.Id, request.UserId) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this AddPostLikeCommand command, AddPostLikeCommandRequest request)
    {
        return command.Id.Matches(request.Id) &&
               command.UserId.Matches(request.UserId);
    }

    public static bool Matches(this DeletePostLikeCommand command, DeletePostLikeCommandRequest request)
    {
        return command.Id.Matches(request.Id, request.UserId);
    }

    public static bool Matches(
        this AddPostLikeCommandResponse response,
        PostLike postLike,
        AddPostLikeCommandRequest request)
    {
        return response.Id.Matches(postLike.Id);
    }

    public static bool Matches(this GetPostLikeByIdQueryResponse response, PostLike postLike, GetPostLikeByIdQueryRequest request)
    {
        return response.PostLike.MatchesFull(postLike, request);
    }

    public static bool Matches(
        this GetAllPostLikesQueryResponse response,
        Post post,
        ICollection<PostLike> postLikes,
        GetAllPostLikesQueryRequest request)
    {
        return response.PostLikeCollection.MatchesWithoutUser(
                   (response, postLike) => response.MatchesWithoutPost(postLike, request),
                   postLike => postLike.MatchesFilter(request),
                   post,
                   postLikes,
                   request);
    }

    public static bool Matches(
        this GetAllPostLikesQueryResponse response,
        Post post,
        ICollection<PostLike> postLikes,
        GetAllPostLikesQueryRequest request,
        ISortEnumTermTransformer<PostLike> termTransformer)
    {
        return response.PostLikeCollection.MatchesWithoutUser(
                   (response, postLike) => response.MatchesWithoutPost(postLike, request),
                   postLike => postLike.MatchesFilter(request),
                   post,
                   postLikes,
                   request,
                   termTransformer);
    }

    public static bool Matches(
        this GetAllPostLikesForUserQueryResponse response,
        User user,
        ICollection<PostLike> postLikes,
        GetAllPostLikesForUserQueryRequest request)
    {
        return response.PostLikeCollection.MatchesWithoutPost(
                   (response, postLike) => response.MatchesWithoutUser(postLike, request),
                   postLike => postLike.MatchesFilter(request),
                   user,
                   postLikes,
                   request);
    }

    public static bool Matches(
        this GetAllPostLikesForUserQueryResponse response,
        User user,
        ICollection<PostLike> postLikes,
        GetAllPostLikesForUserQueryRequest request,
        ISortEnumTermTransformer<PostLike> termTransformer)
    {
        return response.PostLikeCollection.MatchesWithoutPost(
                   (response, postLike) => response.MatchesWithoutUser(postLike, request),
                   postLike => postLike.MatchesFilter(request),
                   user,
                   postLikes,
                   request,
                   termTransformer);
    }

    public static bool Matches(this PostLike postLike, AddPostLikeCommandRequest request)
    {
        return postLike.Id.Matches(request.Id, request.UserId);
    }

    public static bool Matches(this PostLikeIdCommandResponse response, PostLikeId id)
    {
        return id.Matches(response.Id, response.UserId);
    }

    public static bool MatchesFull<TRequest>(this PostLikeQueryResponse? response, PostLike? postLike, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return response != null &&
               postLike != null &&
               postLike.Id.Matches(response.Id, response.UserId) &&
               postLike.CreatedAtUtc == response.CreatedAtUtc &&
               response.User.MatchesFull(postLike.User) &&
               response.Post.MatchesFull(postLike.Post, request);
    }

    public static bool MatchesWithoutUser<TRequest>(this PostLikeQueryResponse? response, PostLike? postLike, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return response != null &&
               postLike != null &&
               postLike.Id.Matches(response.Id, response.UserId) &&
               postLike.CreatedAtUtc == response.CreatedAtUtc &&
               response.User == null &&
               response.Post.MatchesFull(postLike.Post, request);
    }

    public static bool MatchesWithoutUser<TRequest>(
        this PostLikeCollectionQueryResponse response,
        Func<PostLikeQueryResponse, PostLike, bool> matches,
        Func<PostLike, bool> matchesFilter,
        Post post,
        ICollection<PostLike> postLikes,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        return response.MatchesCollectionResponse(postLikes.Count, request) &&
               response.User == null &&
               response.Post.MatchesFull(post, request) &&
               response.PostLikes.MatchesCollection(postLikes,
                                                    response => new(new(response.Id), new(response.UserId)),
                                                    postLike => postLike.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
    }

    public static bool MatchesWithoutUser<TRequest>(
        this PostLikeCollectionQueryResponse response,
        Func<PostLikeQueryResponse, PostLike, bool> matches,
        Func<PostLike, bool> matchesFilter,
        Post post,
        ICollection<PostLike> postLikes,
        TRequest request,
        ISortEnumTermTransformer<PostLike> termTransformer)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        return response.MatchesCollectionResponse(postLikes.Count, request) &&
               response.User == null &&
               response.Post.MatchesFull(post, request) &&
               response.PostLikes.MatchesSortedCollection(postLikes,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
    }

    public static bool MatchesWithoutPost<TRequest>(this PostLikeQueryResponse? response, PostLike? postLike, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return response != null &&
               postLike != null &&
               postLike.Id.Matches(response.Id, response.UserId) &&
               postLike.CreatedAtUtc == response.CreatedAtUtc &&
               response.User.MatchesFull(postLike.User) &&
               response.Post == null;
    }

    public static bool MatchesWithoutPost<TRequest>(
        this PostLikeCollectionQueryResponse response,
        Func<PostLikeQueryResponse, PostLike, bool> matches,
        Func<PostLike, bool> matchesFilter,
        User user,
        ICollection<PostLike> postLikes,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        return response.MatchesCollectionResponse(postLikes.Count, request) &&
               response.User.MatchesFull(user) &&
               response.Post == null &&
               response.PostLikes.MatchesCollection(postLikes,
                                                    response => new(new(response.Id), new(response.UserId)),
                                                    postLike => postLike.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
    }

    public static bool MatchesWithoutPost<TRequest>(
        this PostLikeCollectionQueryResponse response,
        Func<PostLikeQueryResponse, PostLike, bool> matches,
        Func<PostLike, bool> matchesFilter,
        User user,
        ICollection<PostLike> postLikes,
        TRequest request,
        ISortEnumTermTransformer<PostLike> termTransformer)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        return response.MatchesCollectionResponse(postLikes.Count, request) &&
               response.User.MatchesFull(user) &&
               response.Post == null &&
               response.PostLikes.MatchesSortedCollection(postLikes,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
    }

    public static bool MatchesFilter(this GetAllPostLikesQuery query, GetAllPostLikesQueryRequest request)
    {
        return query.Filter.Id.Matches(request.Id) &&
               query.Filter.UserName.Matches(request.UserName);
    }

    public static bool MatchesFilter(this PostLike postLike, GetAllPostLikesQueryRequest request)
    {
        return postLike.Id.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
               postLike.User != null &&
               postLike.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
    }

    public static bool MatchesFilter(this GetAllPostLikesForUserQuery query, GetAllPostLikesForUserQueryRequest request)
    {
        return query.Filter.UserId.Matches(request.UserId);
    }

    public static bool MatchesFilter(this PostLike postLike, GetAllPostLikesForUserQueryRequest request)
    {
        return postLike.Id.UserId.Id.StartsWithOrdinalIgnoreCase(request.UserId);
    }
}
