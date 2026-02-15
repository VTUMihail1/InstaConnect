using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
    public static bool Matches(this GetAllPostCommentsQueryRequest query, GetAllPostCommentsApiRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostCommentsQueryRequest, GetAllPostCommentsApiRequest, PostCommentsSortTerm>(request) &&
               query.MatchesPaginatable(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this GetAllPostCommentsForUserQueryRequest query, GetAllPostCommentsForUserApiRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostCommentsForUserQueryRequest, GetAllPostCommentsForUserApiRequest, PostCommentsSortTerm>(request) &&
               query.MatchesPaginatable(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this GetPostCommentByIdQueryRequest query, GetPostCommentByIdApiRequest request)
    {
        return query.Id == request.Id &&
               query.CommentId == request.CommentId &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this AddPostCommentCommandRequest command, AddPostCommentApiRequest request)
    {
        return command.Id == request.Id &&
               command.Content == request.Body.Content &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this UpdatePostCommentCommandRequest command, UpdatePostCommentApiRequest request)
    {
        return command.Id == request.Id &&
               command.CommentId == request.CommentId &&
               command.Content == request.Body.Content &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this DeletePostCommentCommandRequest command, DeletePostCommentApiRequest request)
    {
        return command.Id == request.Id &&
               command.CommentId == request.CommentId &&
               command.UserId == request.UserId;
    }

    public static bool Matches(
        this AddPostCommentApiResponse response,
        PostComment postComment,
        AddPostCommentApiRequest request)
    {
        return response.Id.Matches(postComment.Id);
    }

    public static bool Matches(
        this UpdatePostCommentApiResponse response,
        PostComment postComment,
        UpdatePostCommentApiRequest request)
    {
        return response.Id.Matches(postComment.Id);
    }

    public static bool Matches(this GetPostCommentByIdApiResponse response, PostComment postComment, GetPostCommentByIdApiRequest request)
    {
        return response.PostComment.MatchesFull(postComment, request);
    }

    public static bool Matches(
        this GetAllPostCommentsApiResponse response,
        Post post,
        ICollection<PostComment> postComments,
        GetAllPostCommentsApiRequest request)
    {
        return response.PostCommentCollection.MatchesWithoutUser(
                   (response, postComment) => response.MatchesWithoutPost(postComment, request),
                   postComment => postComment.MatchesFilter(request),
                   post,
                   postComments,
                   request);
    }

    public static bool Matches(
        this GetAllPostCommentsApiResponse response,
        Post post,
        ICollection<PostComment> postComments,
        GetAllPostCommentsApiRequest request,
        ISortEnumTermTransformer<PostComment> termTransformer)
    {
        return response.PostCommentCollection.MatchesWithoutUser(
                   (response, postComment) => response.MatchesWithoutPost(postComment, request),
                   postComment => postComment.MatchesFilter(request),
                   post,
                   postComments,
                   request,
                   termTransformer);
    }

    public static bool Matches(
        this GetAllPostCommentsForUserApiResponse response,
        User user,
        ICollection<PostComment> postComments,
        GetAllPostCommentsForUserApiRequest request)
    {
        return response.PostCommentCollection.MatchesWithoutPost(
                   (response, postComment) => response.MatchesWithoutUser(postComment, request),
                   postComment => postComment.MatchesFilter(request),
                   user,
                   postComments,
                   request);
    }

    public static bool Matches(
        this GetAllPostCommentsForUserApiResponse response,
        User user,
        ICollection<PostComment> postComments,
        GetAllPostCommentsForUserApiRequest request,
        ISortEnumTermTransformer<PostComment> termTransformer)
    {
        return response.PostCommentCollection.MatchesWithoutPost(
                   (response, postComment) => response.MatchesWithoutUser(postComment, request),
                   postComment => postComment.MatchesFilter(request),
                   user,
                   postComments,
                   request,
                   termTransformer);
    }

    public static bool Matches(this PostComment postComment, AddPostCommentApiRequest request)
    {
        return postComment.Id.Id.Matches(request.Id) &&
               postComment.UserId.Matches(request.UserId) &&
               postComment.Content == request.Body.Content;
    }

    public static bool Matches(this PostComment postComment, UpdatePostCommentApiRequest request)
    {
        return postComment.Id.Matches(request.Id, request.CommentId) &&
               postComment.UserId.Matches(request.UserId) &&
               postComment.Content == request.Body.Content;
    }

    public static bool Matches(this PostCommentIdApiResponse response, PostCommentId id)
    {
        return id.Matches(response.Id, response.CommentId);
    }

    public static bool MatchesFull<TRequest>(this PostCommentApiResponse? response, PostComment? postComment, TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return response != null &&
               postComment != null &&
               postComment.Id.Matches(response.Id, response.CommentId) &&
               postComment.UserId.Matches(response.UserId) &&
               postComment.Content == response.Content &&
               response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
               postComment.CreatedAtUtc == response.CreatedAtUtc &&
               postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
               response.User.MatchesFull(postComment.User) &&
               response.Post.MatchesFull(postComment.Post, request);
    }

    public static bool MatchesWithoutUser<TRequest>(this PostCommentApiResponse? response, PostComment? postComment, TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return response != null &&
               postComment != null &&
               postComment.Id.Matches(response.Id, response.CommentId) &&
               postComment.UserId.Matches(response.UserId) &&
               postComment.Content == response.Content &&
               response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
               postComment.CreatedAtUtc == response.CreatedAtUtc &&
               postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
               response.User == null &&
               response.Post.MatchesFull(postComment.Post, request);
    }

    public static bool MatchesWithoutUser<TRequest>(
        this PostCommentCollectionApiResponse response,
        Func<PostCommentApiResponse, PostComment, bool> matches,
        Func<PostComment, bool> matchesFilter,
        Post post,
        ICollection<PostComment> postComments,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        return response.MatchesCollectionResponse(postComments.Count(matchesFilter), request) &&
               response.User == null &&
               response.Post.MatchesFull(post, request) &&
               response.PostComments.MatchesCollection(postComments,
                                                    response => new(new(response.Id), response.CommentId),
                                                    postComment => postComment.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
    }

    public static bool MatchesWithoutUser<TRequest>(
        this PostCommentCollectionApiResponse response,
        Func<PostCommentApiResponse, PostComment, bool> matches,
        Func<PostComment, bool> matchesFilter,
        Post post,
        ICollection<PostComment> postComments,
        TRequest request,
        ISortEnumTermTransformer<PostComment> termTransformer)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        return response.MatchesCollectionResponse(postComments.Count(matchesFilter), request) &&
               response.User == null &&
               response.Post.MatchesFull(post, request) &&
               response.PostComments.MatchesSortedCollection(postComments,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
    }

    public static bool MatchesWithoutPost<TRequest>(this PostCommentApiResponse? response, PostComment? postComment, TRequest request)
        where TRequest : ICurrentUserableApiRequest
    {
        return response != null &&
               postComment != null &&
               postComment.Id.Matches(response.Id, response.CommentId) &&
               postComment.UserId.Matches(response.UserId) &&
               postComment.Content == response.Content &&
               response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
               postComment.CreatedAtUtc == response.CreatedAtUtc &&
               postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
               response.User.MatchesFull(postComment.User) &&
               response.Post == null;
    }

    public static bool MatchesWithoutPost<TRequest>(
        this PostCommentCollectionApiResponse response,
        Func<PostCommentApiResponse, PostComment, bool> matches,
        Func<PostComment, bool> matchesFilter,
        User user,
        ICollection<PostComment> postComments,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        return response.MatchesCollectionResponse(postComments.Count(matchesFilter), request) &&
               response.User.MatchesFull(user) &&
               response.Post == null &&
               response.PostComments.MatchesCollection(postComments,
                                                    response => new(new(response.Id), response.CommentId),
                                                    postComment => postComment.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
    }

    public static bool MatchesWithoutPost<TRequest>(
        this PostCommentCollectionApiResponse response,
        Func<PostCommentApiResponse, PostComment, bool> matches,
        Func<PostComment, bool> matchesFilter,
        User user,
        ICollection<PostComment> postComments,
        TRequest request,
        ISortEnumTermTransformer<PostComment> termTransformer)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
    {
        return response.MatchesCollectionResponse(postComments.Count(matchesFilter), request) &&
               response.User.MatchesFull(user) &&
               response.Post == null &&
               response.PostComments.MatchesSortedCollection(postComments,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
    }

    public static bool MatchesFilter(this GetAllPostCommentsQueryRequest query, GetAllPostCommentsApiRequest request)
    {
        return query.Id == request.Id &&
               query.UserName == request.UserName;
    }

    public static bool MatchesFilter(this PostComment postComment, GetAllPostCommentsApiRequest request)
    {
        return postComment.Id.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
               postComment.User != null &&
               postComment.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
    }

    public static bool MatchesFilter(this GetAllPostCommentsForUserQueryRequest query, GetAllPostCommentsForUserApiRequest request)
    {
        return query.UserId == request.UserId;
    }

    public static bool MatchesFilter(this PostComment postComment, GetAllPostCommentsForUserApiRequest request)
    {
        return postComment.UserId.Id.EqualsOrdinalIgnoreCase(request.UserId);
    }
}
