using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
    public static bool Matches(this GetAllPostCommentsQuery query, GetAllPostCommentsQueryRequest request, CommonIncludeQuery<PostCommentIncludeProperty> include)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostCommentsQuery, GetAllPostCommentsQueryRequest, PostCommentSortProperty>(request) &&
               query.MatchesPaginatable(request) &&
               query.MatchesIncludable(include);
    }

    public static bool Matches(this GetPostCommentByIdQuery query, GetPostCommentByIdQueryRequest request, CommonIncludeQuery<PostCommentIncludeProperty> include)
    {
        return query.Id.Matches(request.Id, request.CommentId) &&
               query.MatchesIncludable(include);
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

    public static bool Matches(this AddPostCommentCommandResponse response, PostComment postComment)
    {
        return response.Response.Matches(postComment.Id);
    }

    public static bool Matches(this UpdatePostCommentCommandResponse response, PostComment postComment)
    {
        return response.Response.Matches(postComment.Id);
    }

    public static bool Matches(this GetPostCommentByIdQueryResponse response, PostComment postComment)
    {
        return response.Response.Matches(postComment);
    }

    public static bool Matches(
        this GetAllPostCommentsQueryResponse response,
        ICollection<PostComment> postComments,
        GetAllPostCommentsQueryRequest request)
    {
        return response.Response.MatchesCollectionResponse(postComments.Count, request) &&
               response.Response.Entities.MatchesCollection(postComments,
                                                            response => response.CommentId,
                                                            postComment => postComment.Id.CommentId,
                                                            (response, postComment) => response.Matches(postComment),
                                                            request,
                                                            postComment => postComment.MatchesFilter(request));
    }

    public static bool Matches(
        this GetAllPostCommentsQueryResponse response,
        ICollection<PostComment> postComments,
        GetAllPostCommentsQueryRequest request,
        ISortEnumTermTransformer<PostComment> termTransformer)
    {
        return response.Response.MatchesCollectionResponse(postComments.Count, request) &&
               response.Response.Entities.MatchesSortedCollection(postComments,
                                                                  (response, postComment) => response.Matches(postComment),
                                                                  termTransformer,
                                                                  request,
                                                                  postComment => postComment.MatchesFilter(request));
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

    public static bool Matches(this PostCommentQueryResponse response, PostComment postComment)
    {
        return postComment.Id.Matches(response.Id, response.CommentId) &&
               response.Content == postComment.Content &&
               response.User.Matches(postComment.User!) &&
               response.CreatedAtUtc == postComment.CreatedAtUtc &&
               response.UpdatedAtUtc == postComment.UpdatedAtUtc;
    }

    public static bool MatchesFilter(this GetAllPostCommentsQuery query, GetAllPostCommentsQueryRequest request)
    {
        return query.Filter.Id.Id == request.Id &&
               query.Filter.UserName.Value == request.UserName;
    }

    public static bool MatchesFilter(this PostComment postComment, GetAllPostCommentsQueryRequest request)
    {
        return postComment.Id.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
               postComment.User!.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
    }
}
