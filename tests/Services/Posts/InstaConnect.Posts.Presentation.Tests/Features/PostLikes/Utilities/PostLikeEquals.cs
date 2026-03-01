using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
    public static bool Matches(this GetAllPostLikesQueryRequest query, GetAllPostLikesApiRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostLikesQueryRequest, GetAllPostLikesApiRequest, PostLikesSortTerm>(request) &&
               query.MatchesPaginatable(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this GetAllPostLikesForUserQueryRequest query, GetAllPostLikesForUserApiRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostLikesForUserQueryRequest, GetAllPostLikesForUserApiRequest, PostLikesForUserSortTerm>(request) &&
               query.MatchesPaginatable(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this GetPostLikeByIdQueryRequest query, GetPostLikeByIdApiRequest request)
    {
        return query.Id == request.Id &&
               query.UserId == request.UserId &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this AddPostLikeCommandRequest command, AddPostLikeApiRequest request)
    {
        return command.Id == request.Id &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this DeletePostLikeCommandRequest command, DeletePostLikeApiRequest request)
    {
        return command.Id == request.Id &&
               command.UserId == request.UserId;
    }

    public static bool Matches(
        this AddPostLikeApiResponse response,
        PostLike postLike,
        AddPostLikeApiRequest request)
    {
        return response.Id.Matches(postLike.Id);
    }

    public static bool Matches(this GetPostLikeByIdApiResponse response, PostLike postLike, GetPostLikeByIdApiRequest request)
    {
        return response.PostLike.MatchesFull(postLike, request);
    }

    public static bool Matches(
        this GetAllPostLikesApiResponse response,
        Post post,
        ICollection<PostLike> postLikes,
        GetAllPostLikesApiRequest request)
    {
        return response.PostLikeCollection.MatchesWithoutUser(
                   (response, postLike) => response.MatchesWithoutPost(postLike, request),
                   postLike => postLike.MatchesFilter(request),
                   post,
                   postLikes,
                   request);
    }

    public static bool Matches(
        this GetAllPostLikesApiResponse response,
        Post post,
        ICollection<PostLike> postLikes,
        GetAllPostLikesApiRequest request,
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
        this GetAllPostLikesForUserApiResponse response,
        User user,
        ICollection<PostLike> postLikes,
        GetAllPostLikesForUserApiRequest request)
    {
        return response.PostLikeCollection.MatchesWithoutPost(
                   (response, postLike) => response.MatchesWithoutUser(postLike, request),
                   postLike => postLike.MatchesFilter(request),
                   user,
                   postLikes,
                   request);
    }

    public static bool Matches(
        this GetAllPostLikesForUserApiResponse response,
        User user,
        ICollection<PostLike> postLikes,
        GetAllPostLikesForUserApiRequest request,
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

    public static bool Matches(this PostLike postLike, AddPostLikeApiRequest request)
    {
        return postLike.Id.Matches(request.Id, request.UserId);
    }

    public static bool Matches(this PostLikeIdApiResponse response, PostLikeId id)
    {
        return id.Matches(response.Id, response.UserId);
    }

    public static bool MatchesFull<TRequest>(this PostLikeApiResponse? response, PostLike? postLike, TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return response != null &&
               postLike != null &&
               postLike.Id.Matches(response.Id, response.UserId) &&
               postLike.CreatedAtUtc == response.CreatedAtUtc &&
               response.User.MatchesFull(postLike.User) &&
               response.Post.MatchesFull(postLike.Post, request);
    }

    public static bool MatchesWithoutUser<TRequest>(this PostLikeApiResponse? response, PostLike? postLike, TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return response != null &&
               postLike != null &&
               postLike.Id.Matches(response.Id, response.UserId) &&
               postLike.CreatedAtUtc == response.CreatedAtUtc &&
               response.User == null &&
               response.Post.MatchesFull(postLike.Post, request);
    }

    public static bool MatchesWithoutUser<TRequest>(
        this PostLikeCollectionApiResponse response,
        Func<PostLikeApiResponse, PostLike, bool> matches,
        Func<PostLike, bool> matchesFilter,
        Post post,
        ICollection<PostLike> postLikes,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        return response.MatchesCollectionResponse(postLikes.Count(matchesFilter), request) &&
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
        this PostLikeCollectionApiResponse response,
        Func<PostLikeApiResponse, PostLike, bool> matches,
        Func<PostLike, bool> matchesFilter,
        Post post,
        ICollection<PostLike> postLikes,
        TRequest request,
        ISortEnumTermTransformer<PostLike> termTransformer)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        return response.MatchesCollectionResponse(postLikes.Count(matchesFilter), request) &&
               response.User == null &&
               response.Post.MatchesFull(post, request) &&
               response.PostLikes.MatchesSortedCollection(postLikes,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
    }

    public static bool MatchesWithoutPost<TRequest>(this PostLikeApiResponse? response, PostLike? postLike, TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return response != null &&
               postLike != null &&
               postLike.Id.Matches(response.Id, response.UserId) &&
               postLike.CreatedAtUtc == response.CreatedAtUtc &&
               response.User.MatchesFull(postLike.User) &&
               response.Post == null;
    }

    public static bool MatchesWithoutPost<TRequest>(
        this PostLikeCollectionApiResponse response,
        Func<PostLikeApiResponse, PostLike, bool> matches,
        Func<PostLike, bool> matchesFilter,
        User user,
        ICollection<PostLike> postLikes,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        return response.MatchesCollectionResponse(postLikes.Count(matchesFilter), request) &&
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
        this PostLikeCollectionApiResponse response,
        Func<PostLikeApiResponse, PostLike, bool> matches,
        Func<PostLike, bool> matchesFilter,
        User user,
        ICollection<PostLike> postLikes,
        TRequest request,
        ISortEnumTermTransformer<PostLike> termTransformer)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        return response.MatchesCollectionResponse(postLikes.Count(matchesFilter), request) &&
               response.User.MatchesFull(user) &&
               response.Post == null &&
               response.PostLikes.MatchesSortedCollection(postLikes,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
    }

    public static bool MatchesFilter(this GetAllPostLikesQueryRequest query, GetAllPostLikesApiRequest request)
    {
        return query.Id == request.Id &&
               query.UserName == request.UserName;
    }

    public static bool MatchesFilter(this PostLike postLike, GetAllPostLikesApiRequest request)
    {
        return postLike.Id.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
               postLike.User != null &&
               postLike.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
    }

    public static bool MatchesFilter(this GetAllPostLikesForUserQueryRequest query, GetAllPostLikesForUserApiRequest request)
    {
        return query.UserId == request.UserId;
    }

    public static bool MatchesFilter(this PostLike postLike, GetAllPostLikesForUserApiRequest request)
    {
        return postLike.Id.UserId.Id.StartsWithOrdinalIgnoreCase(request.UserId);
    }
}
