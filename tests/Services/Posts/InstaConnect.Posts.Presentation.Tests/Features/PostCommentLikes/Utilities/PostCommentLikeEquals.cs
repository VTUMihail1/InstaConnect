using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
    public static bool Matches(this GetAllPostCommentLikesQueryRequest query, GetAllPostCommentLikesApiRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostCommentLikesQueryRequest, GetAllPostCommentLikesApiRequest, PostCommentLikesSortTerm>(request) &&
               query.MatchesPaginatable(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this GetAllPostCommentLikesForUserQueryRequest query, GetAllPostCommentLikesForUserApiRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostCommentLikesForUserQueryRequest, GetAllPostCommentLikesForUserApiRequest, PostCommentLikesSortTerm>(request) &&
               query.MatchesPaginatable(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this GetPostCommentLikeByIdQueryRequest query, GetPostCommentLikeByIdApiRequest request)
    {
        return query.Id == request.Id &&
               query.CommentId == request.CommentId &&
               query.UserId == request.UserId &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this AddPostCommentLikeCommandRequest command, AddPostCommentLikeApiRequest request)
    {
        return command.Id == request.Id &&
               command.CommentId == request.CommentId &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this DeletePostCommentLikeCommandRequest command, DeletePostCommentLikeApiRequest request)
    {
        return command.Id == request.Id &&
               command.CommentId == request.CommentId &&
               command.UserId == request.UserId;
    }

    public static bool Matches(
        this AddPostCommentLikeApiResponse response,
        PostCommentLike postCommentLike,
        AddPostCommentLikeApiRequest request)
    {
        return response.Id.Matches(postCommentLike.Id);
    }

    public static bool Matches(this GetPostCommentLikeByIdApiResponse response, PostCommentLike postCommentLike, GetPostCommentLikeByIdApiRequest request)
    {
        return response.PostCommentLike.MatchesFull(postCommentLike, request);
    }

    public static bool Matches(
        this GetAllPostCommentLikesApiResponse response,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesApiRequest request)
    {
        return response.PostCommentLikeCollection.MatchesWithoutUser(
                   (response, postCommentLike) => response.MatchesWithoutPostComment(postCommentLike, request),
                   postCommentLike => postCommentLike.MatchesFilter(request),
                   postCommentLikes,
                   request);
    }

    public static bool Matches(
        this GetAllPostCommentLikesApiResponse response,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesApiRequest request,
        ISortEnumTermTransformer<PostCommentLike> termTransformer)
    {
        return response.PostCommentLikeCollection.MatchesWithoutUser(
                   (response, postCommentLike) => response.MatchesWithoutPostComment(postCommentLike, request),
                   postCommentLike => postCommentLike.MatchesFilter(request),
                   postCommentLikes,
                   request,
                   termTransformer);
    }

    public static bool Matches(
        this GetAllPostCommentLikesForUserApiResponse response,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesForUserApiRequest request)
    {
        return response.PostCommentLikeCollection.MatchesWithoutPostComment(
                   (response, postCommentLike) => response.MatchesWithoutUser(postCommentLike, request),
                   postCommentLike => postCommentLike.MatchesFilter(request),
                   postCommentLikes,
                   request);
    }

    public static bool Matches(
        this GetAllPostCommentLikesForUserApiResponse response,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesForUserApiRequest request,
        ISortEnumTermTransformer<PostCommentLike> termTransformer)
    {
        return response.PostCommentLikeCollection.MatchesWithoutPostComment(
                   (response, postCommentLike) => response.MatchesWithoutUser(postCommentLike, request),
                   postCommentLike => postCommentLike.MatchesFilter(request),
                   postCommentLikes,
                   request,
                   termTransformer);
    }

    public static bool Matches(this PostCommentLike postCommentLike, AddPostCommentLikeApiRequest request)
    {
        return postCommentLike.Id.Matches(request.Id, request.CommentId, request.UserId);
    }

    public static bool Matches(this PostCommentLikeIdApiResponse response, PostCommentLikeId id)
    {
        return id.Matches(response.Id, response.CommentId, response.UserId);
    }

    public static bool MatchesFull<TRequest>(this PostCommentLikeApiResponse? response, PostCommentLike? postCommentLike, TRequest request)
    where TRequest : ICurrentUserableApiRequest
    {
        return response != null &&
               postCommentLike != null &&
               postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
               postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
               response.User.MatchesFull(postCommentLike.User) &&
               response.PostComment.MatchesFull(postCommentLike.PostComment, request);
    }

    public static bool MatchesWithoutUser<TRequest>(this PostCommentLikeApiResponse? response, PostCommentLike? postCommentLike, TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return response != null &&
               postCommentLike != null &&
               postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
               postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
               response.User == null &&
               response.PostComment.MatchesFull(postCommentLike.PostComment, request);
    }

    public static bool MatchesWithoutUser<TRequest>(
        this PostCommentLikeCollectionApiResponse response,
        Func<PostCommentLikeApiResponse, PostCommentLike, bool> matches,
        Func<PostCommentLike, bool> matchesFilter,
        ICollection<PostCommentLike> postCommentLikes,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        var postCommentLike = postCommentLikes.FirstOrDefault();

        return response.MatchesCollectionResponse(postCommentLikes.Count, request) &&
               response.User == null &&
               response.PostComment.MatchesFull(postCommentLike?.PostComment, request) &&
               response.PostCommentLikes.MatchesCollection(postCommentLikes,
                                                    response => response.UserId,
                                                    postCommentLike => postCommentLike.Id.UserId.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
    }

    public static bool MatchesWithoutUser<TRequest>(
        this PostCommentLikeCollectionApiResponse response,
        Func<PostCommentLikeApiResponse, PostCommentLike, bool> matches,
        Func<PostCommentLike, bool> matchesFilter,
        ICollection<PostCommentLike> postCommentLikes,
        TRequest request,
        ISortEnumTermTransformer<PostCommentLike> termTransformer)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        var postCommentLike = postCommentLikes.FirstOrDefault();

        return response.MatchesCollectionResponse(postCommentLikes.Count, request) &&
               response.User == null &&
               response.PostComment.MatchesFull(postCommentLike?.PostComment, request) &&
               response.PostCommentLikes.MatchesSortedCollection(postCommentLikes,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
    }

    public static bool MatchesWithoutPostComment<TRequest>(this PostCommentLikeApiResponse? response, PostCommentLike? postCommentLike, TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return response != null &&
               postCommentLike != null &&
               postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
               postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
               response.User.MatchesFull(postCommentLike.User) &&
               response.PostComment == null;
    }

    public static bool MatchesWithoutPostComment<TRequest>(
        this PostCommentLikeCollectionApiResponse response,
        Func<PostCommentLikeApiResponse, PostCommentLike, bool> matches,
        Func<PostCommentLike, bool> matchesFilter,
        ICollection<PostCommentLike> postCommentLikes,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        var postCommentLike = postCommentLikes.FirstOrDefault();

        return response.MatchesCollectionResponse(postCommentLikes.Count, request) &&
               response.User.MatchesFull(postCommentLike?.User) &&
               response.PostComment == null &&
               response.PostCommentLikes.MatchesCollection(postCommentLikes,
                                                    response => response.UserId,
                                                    postCommentLike => postCommentLike.Id.UserId.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
    }

    public static bool MatchesWithoutPostComment<TRequest>(
        this PostCommentLikeCollectionApiResponse response,
        Func<PostCommentLikeApiResponse, PostCommentLike, bool> matches,
        Func<PostCommentLike, bool> matchesFilter,
        ICollection<PostCommentLike> postCommentLikes,
        TRequest request,
        ISortEnumTermTransformer<PostCommentLike> termTransformer)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        var postCommentLike = postCommentLikes.FirstOrDefault();

        return response.MatchesCollectionResponse(postCommentLikes.Count, request) &&
               response.User.MatchesFull(postCommentLike?.User) &&
               response.PostComment == null &&
               response.PostCommentLikes.MatchesSortedCollection(postCommentLikes,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
    }

    public static bool MatchesFilter(this GetAllPostCommentLikesQueryRequest query, GetAllPostCommentLikesApiRequest request)
    {
        return query.Id == request.CommentId &&
               query.CommentId == request.CommentId &&
               query.UserName == request.UserName;
    }

    public static bool MatchesFilter(this PostCommentLike postCommentLike, GetAllPostCommentLikesApiRequest request)
    {
        return postCommentLike.Id.CommentId.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
               postCommentLike.Id.CommentId.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
               postCommentLike.User != null &&
               postCommentLike.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
    }

    public static bool MatchesFilter(this GetAllPostCommentLikesForUserQueryRequest query, GetAllPostCommentLikesForUserApiRequest request)
    {
        return query.UserId == request.UserId;
    }

    public static bool MatchesFilter(this PostCommentLike postCommentLike, GetAllPostCommentLikesForUserApiRequest request)
    {
        return postCommentLike.Id.UserId.Id.EqualsOrdinalIgnoreCase(request.UserId);
    }
}
