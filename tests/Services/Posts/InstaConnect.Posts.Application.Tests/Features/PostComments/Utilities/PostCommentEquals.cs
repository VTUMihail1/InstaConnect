using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
    public static bool Matches(this GetAllPostCommentsQuery query, GetAllPostCommentsQueryRequest request)
    {
        return query.Filter.Id.Matches(request.Id) &&
               query.Filter.UserId.Matches(request.UserId) &&
               query.Filter.UserName.Matches(request.UserName) &&
               query.Pagination.Page == request.Page &&
               query.Pagination.PageSize == request.PageSize &&
               query.Sorting.Order == request.SortOrder &&
               query.Sorting.Property == request.SortProperty &&
               query.Include!.Properties.All(a => a == PostCommentIncludeProperty.User);
    }

    public static bool Matches(this GetPostCommentByIdQuery query, GetPostCommentByIdQueryRequest request)
    {
        return query.Id.Matches(request.Id, request.CommentId) &&
               query.Include!.Properties.All(a => a == PostCommentIncludeProperty.User);
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

    public static bool Matches(this GetPostCommentByIdQueryResponse response, PostComment postComment, User user)
    {
        return response.Response.Matches(postComment, user);
    }

    public static bool Matches(this GetAllPostCommentsQueryResponse response, PostComment postComment, User user, GetAllPostCommentsQueryRequest request)
    {
        return response.Response.Entities.All(p => p.Matches(postComment, user)) &&
               response.Response.Page == request.Page &&
               response.Response.PageSize == request.PageSize &&
               response.Response.TotalCount == response.Response.Entities.Count &&
               response.Response.HasPreviousPage == response.Response.Page > 1 &&
               response.Response.HasNextPage == response.Response.Page * response.Response.PageSize < response.Response.TotalCount;
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

    public static bool Matches(this PostCommentQueryResponse response, PostComment postComment, User user)
    {
        return postComment.Id.Matches(response.Id, response.CommentId) &&
               response.Content == postComment.Content &&
               response.User.Matches(user) &&
               response.CreatedAtUtc == postComment.CreatedAtUtc &&
               response.UpdatedAtUtc == postComment.UpdatedAtUtc;
    }
}
