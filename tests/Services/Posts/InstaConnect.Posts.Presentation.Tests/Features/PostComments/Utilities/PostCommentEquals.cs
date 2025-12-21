using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
    public static bool Matches(this GetAllPostCommentsQueryRequest query, GetAllPostCommentsApiRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostCommentsQueryRequest, GetAllPostCommentsApiRequest, PostCommentSortProperty>(request) &&
               query.MatchesPaginatable(request);
    }

    public static bool Matches(this GetPostCommentByIdQueryRequest query, GetPostCommentByIdApiRequest request)
    {
        return query.Id == request.Id &&
               query.CommentId == request.CommentId;
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

    public static bool Matches(this AddPostCommentApiResponse response, PostComment postComment)
    {
        return response.Response.Matches(postComment.Id);
    }

    public static bool Matches(this UpdatePostCommentApiResponse response, PostComment postComment)
    {
        return response.Response.Matches(postComment.Id);
    }

    public static bool Matches(this GetPostCommentByIdApiResponse response, PostComment postComment)
    {
        return response.Response.Matches(postComment);
    }

    public static bool Matches(
        this GetAllPostCommentsApiResponse response,
        ICollection<PostComment> postComments,
        GetAllPostCommentsApiRequest request)
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
        this GetAllPostCommentsApiResponse response,
        ICollection<PostComment> postComments,
        GetAllPostCommentsApiRequest request,
        ISortEnumTermTransformer<PostComment> termTransformer)
    {
        return response.Response.MatchesCollectionResponse(postComments.Count, request) &&
               response.Response.Entities.MatchesSortedCollection(postComments,
                                                                  (response, postComment) => response.Matches(postComment),
                                                                  termTransformer,
                                                                  request,
                                                                  postComment => postComment.MatchesFilter(request));
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

    public static bool Matches(this PostCommentApiResponse response, PostComment postComment)
    {
        return postComment.Id.Matches(response.Id, response.CommentId) &&
               response.Content == postComment.Content &&
               response.User.Matches(postComment.User!) &&
               response.CreatedAtUtc == postComment.CreatedAtUtc &&
               response.UpdatedAtUtc == postComment.UpdatedAtUtc;
    }

    public static bool MatchesFilter(this GetAllPostCommentsQueryRequest query, GetAllPostCommentsApiRequest request)
    {
        return query.Id == request.Id &&
               query.UserName == request.UserName;
    }

    public static bool MatchesFilter(this PostComment postComment, GetAllPostCommentsApiRequest request)
    {
        return postComment.Id.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
               postComment.User!.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
    }
}
