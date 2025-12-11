using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
    public static bool Matches(this GetAllPostCommentsQueryRequest query, GetAllPostCommentsApiRequest request)
    {
        return query.Id == request.Id &&
               query.UserId == request.UserId &&
               query.UserName == request.UserName &&
               query.Page == request.Page &&
               query.PageSize == request.PageSize &&
               query.SortOrder == request.SortOrder &&
               query.SortProperty == request.SortProperty;
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

    public static bool Matches(this GetPostCommentByIdApiResponse response, PostComment postComment, User user)
    {
        return response.Response.Matches(postComment, user);
    }

    public static bool Matches(this GetAllPostCommentsApiResponse response, PostComment postComment, User user, GetAllPostCommentsApiRequest request)
    {
        return response.Response.Entities.All(p => p.Matches(postComment, user)) &&
               response.Response.Page == request.Page &&
               response.Response.PageSize == request.PageSize &&
               response.Response.TotalCount == response.Response.Entities.Count &&
               response.Response.HasPreviousPage == response.Response.Page > 1 &&
               response.Response.HasNextPage == response.Response.Page * response.Response.PageSize < response.Response.TotalCount;
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

    public static bool Matches(this PostCommentApiResponse response, PostComment postComment, User user)
    {
        return postComment.Id.Matches(response.Id, response.CommentId) &&
               response.Content == postComment.Content &&
               response.User.Matches(user) &&
               response.CreatedAtUtc == postComment.CreatedAtUtc &&
               response.UpdatedAtUtc == postComment.UpdatedAtUtc;
    }
}
