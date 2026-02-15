using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
    public static bool Matches(
        this GetAllPostCommentLikesQuery query,
        GetAllPostCommentLikesQueryRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostCommentLikesQuery, GetAllPostCommentLikesQueryRequest, PostCommentLikesSortTerm, PostCommentLikesSortingQuery>(request) &&
               query.MatchesPaginatable<GetAllPostCommentLikesQuery, GetAllPostCommentLikesQueryRequest, PostCommentLikesPaginationQuery>(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(
        this GetAllPostCommentLikesForUserQuery query,
        GetAllPostCommentLikesForUserQueryRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostCommentLikesForUserQuery, GetAllPostCommentLikesForUserQueryRequest, PostCommentLikesSortTerm, PostCommentLikesSortingQuery>(request) &&
               query.MatchesPaginatable<GetAllPostCommentLikesForUserQuery, GetAllPostCommentLikesForUserQueryRequest, PostCommentLikesPaginationQuery>(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(
        this GetPostCommentLikeByIdQuery query,
        GetPostCommentLikeByIdQueryRequest request)
    {
        return query.Id.Matches(request.Id, request.CommentId, request.UserId) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this AddPostCommentLikeCommand command, AddPostCommentLikeCommandRequest request)
    {
        return command.CommentId.Matches(request.Id, request.CommentId) &&
               command.UserId.Matches(request.UserId);
    }

    public static bool Matches(this DeletePostCommentLikeCommand command, DeletePostCommentLikeCommandRequest request)
    {
        return command.Id.Matches(request.Id, request.CommentId, request.UserId);
    }

    public static bool Matches(
        this AddPostCommentLikeCommandResponse response,
        PostCommentLike postCommentLike,
        AddPostCommentLikeCommandRequest request)
    {
        return response.Id.Matches(postCommentLike.Id);
    }

    public static bool Matches(this GetPostCommentLikeByIdQueryResponse response, PostCommentLike postCommentLike, GetPostCommentLikeByIdQueryRequest request)
    {
        return response.PostCommentLike.MatchesFull(postCommentLike, request);
    }

    public static bool Matches(
        this GetAllPostCommentLikesQueryResponse response,
        PostComment postComment,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesQueryRequest request)
    {
        return response.PostCommentLikeCollection.MatchesWithoutUser(
                   (response, postCommentLike) => response.MatchesWithoutPostComment(postCommentLike, request),
                   postCommentLike => postCommentLike.MatchesFilter(request),
                   postComment,
                   postCommentLikes,
                   request);
    }

    public static bool Matches(
        this GetAllPostCommentLikesQueryResponse response,
        PostComment postComment,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesQueryRequest request,
        ISortEnumTermTransformer<PostCommentLike> termTransformer)
    {
        return response.PostCommentLikeCollection.MatchesWithoutUser(
                   (response, postCommentLike) => response.MatchesWithoutPostComment(postCommentLike, request),
                   postCommentLike => postCommentLike.MatchesFilter(request),
                   postComment,
                   postCommentLikes,
                   request,
                   termTransformer);
    }

    public static bool Matches(
        this GetAllPostCommentLikesForUserQueryResponse response,
        User user,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesForUserQueryRequest request)
    {
        return response.PostCommentLikeCollection.MatchesWithoutPostComment(
                   (response, postCommentLike) => response.MatchesWithoutUser(postCommentLike, request),
                   postCommentLike => postCommentLike.MatchesFilter(request),
                   user,
                   postCommentLikes,
                   request);
    }

    public static bool Matches(
        this GetAllPostCommentLikesForUserQueryResponse response,
        User user,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesForUserQueryRequest request,
        ISortEnumTermTransformer<PostCommentLike> termTransformer)
    {
        return response.PostCommentLikeCollection.MatchesWithoutPostComment(
                   (response, postCommentLike) => response.MatchesWithoutUser(postCommentLike, request),
                   postCommentLike => postCommentLike.MatchesFilter(request),
                   user,
                   postCommentLikes,
                   request,
                   termTransformer);
    }

    public static bool Matches(this PostCommentLike postCommentLike, AddPostCommentLikeCommandRequest request)
    {
        return postCommentLike.Id.Matches(request.Id, request.CommentId, request.UserId);
    }

    public static bool Matches(this PostCommentLikeIdCommandResponse response, PostCommentLikeId id)
    {
        return id.Matches(response.Id, response.CommentId, response.UserId);
    }

    public static bool MatchesFull<TRequest>(this PostCommentLikeQueryResponse? response, PostCommentLike? postCommentLike, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return response != null &&
               postCommentLike != null &&
               postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
               postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
               response.User.MatchesFull(postCommentLike.User) &&
               response.PostComment.MatchesFull(postCommentLike.PostComment, request);
    }

    public static bool MatchesWithoutUser<TRequest>(this PostCommentLikeQueryResponse? response, PostCommentLike? postCommentLike, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return response != null &&
               postCommentLike != null &&
               postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
               postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
               response.User == null &&
               response.PostComment.MatchesFull(postCommentLike.PostComment, request);
    }

    public static bool MatchesWithoutUser<TRequest>(
        this PostCommentLikeCollectionQueryResponse response,
        Func<PostCommentLikeQueryResponse, PostCommentLike, bool> matches,
        Func<PostCommentLike, bool> matchesFilter,
        PostComment postComment,
        ICollection<PostCommentLike> postCommentLikes,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        return response.MatchesCollectionResponse(postCommentLikes.Count(matchesFilter), request) &&
               response.User == null &&
               response.PostComment.MatchesFull(postComment, request) &&
               response.PostCommentLikes.MatchesCollection(postCommentLikes,
                                                    response => new(new(new(response.Id), response.CommentId), new(response.UserId)),
                                                    postCommentLike => postCommentLike.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
    }

    public static bool MatchesWithoutUser<TRequest>(
        this PostCommentLikeCollectionQueryResponse response,
        Func<PostCommentLikeQueryResponse, PostCommentLike, bool> matches,
        Func<PostCommentLike, bool> matchesFilter,
        PostComment postComment,
        ICollection<PostCommentLike> postCommentLikes,
        TRequest request,
        ISortEnumTermTransformer<PostCommentLike> termTransformer)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        return response.MatchesCollectionResponse(postCommentLikes.Count(matchesFilter), request) &&
               response.User == null &&
               response.PostComment.MatchesFull(postComment, request) &&
               response.PostCommentLikes.MatchesSortedCollection(postCommentLikes,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
    }

    public static bool MatchesWithoutPostComment<TRequest>(this PostCommentLikeQueryResponse? response, PostCommentLike? postCommentLike, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
    {
        return response != null &&
               postCommentLike != null &&
               postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
               postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
               response.User.MatchesFull(postCommentLike.User) &&
               response.PostComment == null;
    }

    public static bool MatchesWithoutPostComment<TRequest>(
        this PostCommentLikeCollectionQueryResponse response,
        Func<PostCommentLikeQueryResponse, PostCommentLike, bool> matches,
        Func<PostCommentLike, bool> matchesFilter,
        User user,
        ICollection<PostCommentLike> postCommentLikes,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        return response.MatchesCollectionResponse(postCommentLikes.Count(matchesFilter), request) &&
               response.User.MatchesFull(user) &&
               response.PostComment == null &&
               response.PostCommentLikes.MatchesCollection(postCommentLikes,
                                                    response => new(new(new(response.Id), response.CommentId), new(response.UserId)),
                                                    postCommentLike => postCommentLike.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
    }

    public static bool MatchesWithoutPostComment<TRequest>(
        this PostCommentLikeCollectionQueryResponse response,
        Func<PostCommentLikeQueryResponse, PostCommentLike, bool> matches,
        Func<PostCommentLike, bool> matchesFilter,
        User user,
        ICollection<PostCommentLike> postCommentLikes,
        TRequest request,
        ISortEnumTermTransformer<PostCommentLike> termTransformer)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
    {
        return response.MatchesCollectionResponse(postCommentLikes.Count(matchesFilter), request) &&
               response.User.MatchesFull(user) &&
               response.PostComment == null &&
               response.PostCommentLikes.MatchesSortedCollection(postCommentLikes,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
    }

    public static bool MatchesFilter(this GetAllPostCommentLikesQuery query, GetAllPostCommentLikesQueryRequest request)
    {
        return query.Filter.CommentId.Matches(request.Id, request.CommentId) &&
               query.Filter.UserName.Matches(request.UserName);
    }

    public static bool MatchesFilter(this PostCommentLike postCommentLike, GetAllPostCommentLikesQueryRequest request)
    {
        return postCommentLike.Id.CommentId.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
               postCommentLike.Id.CommentId.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
               postCommentLike.User != null &&
               postCommentLike.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
    }

    public static bool MatchesFilter(this GetAllPostCommentLikesForUserQuery query, GetAllPostCommentLikesForUserQueryRequest request)
    {
        return query.Filter.UserId.Matches(request.UserId);
    }

    public static bool MatchesFilter(this PostCommentLike postCommentLike, GetAllPostCommentLikesForUserQueryRequest request)
    {
        return postCommentLike.Id.UserId.Id.EqualsOrdinalIgnoreCase(request.UserId);
    }
}
