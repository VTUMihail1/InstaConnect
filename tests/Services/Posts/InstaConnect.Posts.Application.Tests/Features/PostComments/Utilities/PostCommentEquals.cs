using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
    public static bool Matches(this GetAllPostCommentsQuery query, GetAllPostCommentsQueryRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostCommentsQuery, GetAllPostCommentsQueryRequest, PostCommentsSortTerm, PostCommentsSortingQuery>(request) &&
               query.MatchesPaginatable<GetAllPostCommentsQuery, GetAllPostCommentsQueryRequest, PostCommentsPaginationQuery>(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this GetAllPostCommentsForUserQuery query, GetAllPostCommentsForUserQueryRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostCommentsForUserQuery, GetAllPostCommentsForUserQueryRequest, PostCommentsForUserSortTerm, PostCommentsForUserSortingQuery>(request) &&
               query.MatchesPaginatable<GetAllPostCommentsForUserQuery, GetAllPostCommentsForUserQueryRequest, PostCommentsPaginationQuery>(request) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this GetPostCommentByIdQuery query, GetPostCommentByIdQueryRequest request)
    {
        return query.Id.Matches(request.Id, request.CommentId) &&
               query.MatchesCurrentUserable(request);
    }

    public static bool Matches(this AddPostCommentCommand command, AddPostCommentCommandRequest request)
    {
        return command.Id.Matches(request.Id) &&
               command.UserId.Matches(request.UserId) &&
               command.Content == request.Content;
    }

    public static bool Matches(this UpdatePostCommentCommand command, UpdatePostCommentCommandRequest request)
    {
        return command.Id.Matches(request.Id, request.CommentId) &&
               command.UserId.Matches(request.UserId) &&
               command.Content == request.Content;
    }

    public static bool Matches(this DeletePostCommentCommand command, DeletePostCommentCommandRequest request)
    {
        return command.Id.Matches(request.Id, request.CommentId) &&
               command.UserId.Matches(request.UserId);
    }

    public static bool Matches(
        this AddPostCommentCommandResponse response,
        PostComment postComment,
        AddPostCommentCommandRequest request)
    {
        return response.Id.Matches(postComment.Id);
    }

    public static bool Matches(
        this UpdatePostCommentCommandResponse response,
        PostComment postComment,
        UpdatePostCommentCommandRequest request)
    {
        return response.Id.Matches(postComment.Id);
    }

    public static bool Matches(this GetPostCommentByIdQueryResponse response, PostComment postComment, GetPostCommentByIdQueryRequest request)
    {
        return response.PostComment.MatchesFull(postComment, request);
    }

    public static bool Matches(
        this GetAllPostCommentsQueryResponse response,
        Post post,
        ICollection<PostComment> postComments,
        GetAllPostCommentsQueryRequest request)
    {
        return response.PostCommentCollection.MatchesWithoutUser(
                   (response, postComment) => response.MatchesWithoutPost(postComment, request),
                   postComment => postComment.MatchesFilter(request),
                   post,
                   postComments,
                   request);
    }

    public static bool Matches(
        this GetAllPostCommentsQueryResponse response,
        Post post,
        ICollection<PostComment> postComments,
        GetAllPostCommentsQueryRequest request,
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
        this GetAllPostCommentsForUserQueryResponse response,
        User user,
        ICollection<PostComment> postComments,
        GetAllPostCommentsForUserQueryRequest request)
    {
        return response.PostCommentCollection.MatchesWithoutPost(
                   (response, postComment) => response.MatchesWithoutUser(postComment, request),
                   postComment => postComment.MatchesFilter(request),
                   user,
                   postComments,
                   request);
    }

    public static bool Matches(
        this GetAllPostCommentsForUserQueryResponse response,
        User user,
        ICollection<PostComment> postComments,
        GetAllPostCommentsForUserQueryRequest request,
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

    public static bool Matches(this PostComment postComment, AddPostCommentCommandRequest request)
    {
        return postComment.Id.Id.Matches(request.Id) &&
               postComment.UserId.Matches(request.UserId) &&
               postComment.Content == request.Content;
    }

    public static bool Matches(this PostComment postComment, UpdatePostCommentCommandRequest request)
    {
        return postComment.Id.Matches(request.Id, request.CommentId) &&
               postComment.UserId.Matches(request.UserId) &&
               postComment.Content == request.Content;
    }

    public static bool Matches(this PostCommentIdCommandResponse response, PostCommentId id)
    {
        return id.Matches(response.Id, response.CommentId);
    }

    public static bool MatchesFull<TRequest>(this PostCommentQueryResponse? response, PostComment? postComment, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
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

    public static bool MatchesWithoutUser<TRequest>(this PostCommentQueryResponse? response, PostComment? postComment, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
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
        this PostCommentCollectionQueryResponse response,
        Func<PostCommentQueryResponse, PostComment, bool> matches,
        Func<PostComment, bool> matchesFilter,
        Post post,
        ICollection<PostComment> postComments,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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
        this PostCommentCollectionQueryResponse response,
        Func<PostCommentQueryResponse, PostComment, bool> matches,
        Func<PostComment, bool> matchesFilter,
        Post post,
        ICollection<PostComment> postComments,
        TRequest request,
        ISortEnumTermTransformer<PostComment> termTransformer)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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

    public static bool MatchesWithoutPost<TRequest>(this PostCommentQueryResponse? response, PostComment? postComment, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
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
        this PostCommentCollectionQueryResponse response,
        Func<PostCommentQueryResponse, PostComment, bool> matches,
        Func<PostComment, bool> matchesFilter,
        User user,
        ICollection<PostComment> postComments,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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
        this PostCommentCollectionQueryResponse response,
        Func<PostCommentQueryResponse, PostComment, bool> matches,
        Func<PostComment, bool> matchesFilter,
        User user,
        ICollection<PostComment> postComments,
        TRequest request,
        ISortEnumTermTransformer<PostComment> termTransformer)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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

    public static bool MatchesFilter(this GetAllPostCommentsQuery query, GetAllPostCommentsQueryRequest request)
    {
        return query.Filter.Id.Matches(request.Id) &&
               query.Filter.UserName.Matches(request.UserName);
    }

    public static bool MatchesFilter(this PostComment postComment, GetAllPostCommentsQueryRequest request)
    {
        return postComment.Id.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
               postComment.User != null &&
               postComment.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
    }

    public static bool MatchesFilter(this GetAllPostCommentsForUserQuery query, GetAllPostCommentsForUserQueryRequest request)
    {
        return query.Filter.UserId.Matches(request.UserId);
    }

    public static bool MatchesFilter(this PostComment postComment, GetAllPostCommentsForUserQueryRequest request)
    {
        return postComment.UserId.Id.EqualsOrdinalIgnoreCase(request.UserId);
    }
}
