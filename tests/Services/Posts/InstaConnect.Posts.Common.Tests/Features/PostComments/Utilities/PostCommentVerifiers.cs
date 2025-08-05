using InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Delete;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Update;
using InstaConnect.PostComments.Application.Features.PostComments.Models;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetById;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Events;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;

public static class PostCommentVerifiers
{
    public static bool IsSatisfied(this PostCommentQueryResponse response, PostComment postComment, User user)
    {
        return response.Id == postComment.Id &&
               response.CommentId == postComment.CommentId &&
               response.Content == postComment.Content &&
               response.User.Id == user.Id &&
               response.User.Name == user.Name &&
               response.User.ProfileImage == user.ProfileImage;
    }

    public static bool IsSatisfied(this PostCommentApiResponse response, PostComment postComment, User user)
    {
        return response.Id == postComment.Id &&
               response.CommentId == postComment.CommentId &&
               response.Content == postComment.Content &&
               response.User.Id == user.Id &&
               response.User.Name == user.Name &&
               response.User.ProfileImage == user.ProfileImage;
    }
    public static bool IsSatisfied(this AddPostCommentCommandResponse response, PostComment postComment)
    {
        return response.Id == postComment.Id &&
               response.CommentId == postComment.CommentId &&
               response.CreatedAt == postComment.CreatedAt &&
               response.UpdatedAt == postComment.UpdatedAt;
    }

    public static bool IsSatisfied(this UpdatePostCommentCommandResponse response, PostComment postComment)
    {
        return response.Id == postComment.Id &&
               response.CommentId == postComment.CommentId &&
               response.CreatedAt == postComment.CreatedAt &&
               response.UpdatedAt == postComment.UpdatedAt;
    }

    public static bool IsSatisfied(this GetPostCommentByIdQueryResponse response, PostComment postComment, User user)
    {
        return response.Data.IsSatisfied(postComment, user);
    }

    public static bool IsSatisfied(this GetAllPostCommentsQueryResponse response, PostComment postComment, User user, GetAllPostCommentsQueryRequest request)
    {
        return response.Data.All(p => p.IsSatisfied(postComment, user)) &&
               response.Page == request.Pagination.Page &&
               response.PageSize == request.Pagination.PageSize &&
               response.TotalCount == response.Data.Count &&
               response.HasPreviousPage == response.Page > 1 &&
               response.HasNextPage == response.Page * response.PageSize < response.TotalCount;
    }

    public static bool IsSatisfied(this AddPostCommentApiResponse response, PostComment postComment)
    {
        return response.Id == postComment.Id &&
               response.CommentId == postComment.CommentId &&
               response.CreatedAt == postComment.CreatedAt &&
               response.UpdatedAt == postComment.UpdatedAt;
    }

    public static bool IsSatisfied(this UpdatePostCommentApiResponse response, PostComment postComment)
    {
        return response.Id == postComment.Id &&
               response.CommentId == postComment.CommentId &&
               response.CreatedAt == postComment.CreatedAt &&
               response.UpdatedAt == postComment.UpdatedAt;
    }

    public static bool IsSatisfied(this GetPostCommentByIdApiResponse response, PostComment postComment, User user)
    {
        return response.Data.IsSatisfied(postComment, user);
    }

    public static bool IsSatisfied(this GetAllPostCommentsApiResponse response, PostComment postComment, User user, GetAllPostCommentsApiRequest request)
    {
        return response.Data.All(p => p.IsSatisfied(postComment, user)) &&
               response.Page == request.Pagination.Page &&
               response.PageSize == request.Pagination.PageSize &&
               response.TotalCount == response.Data.Count &&
               response.HasPreviousPage == response.Page > 1 &&
               response.HasNextPage == response.Page * response.PageSize < response.TotalCount;
    }

    public static bool IsSatisfied(this PostComment postComment, AddPostCommentCommandRequest request)
    {
        return postComment.Id == request.Id &&
               postComment.UserId == request.UserId &&
               postComment.Content == request.Content;
    }

    public static bool IsSatisfied(this PostComment postComment, UpdatePostCommentCommandRequest request)
    {
        return postComment.Id == request.Id &&
               postComment.CommentId == request.CommentId &&
               postComment.UserId == request.UserId &&
               postComment.Content == request.Content;
    }

    public static bool IsSatisfied(this PostComment postComment, AddPostCommentApiRequest request)
    {
        return postComment.Id == request.Id &&
               postComment.UserId == request.UserId &&
               postComment.Content == request.Body.Content;
    }

    public static bool IsSatisfied(this PostComment postComment, UpdatePostCommentApiRequest request)
    {
        return postComment.Id == request.Id &&
               postComment.CommentId == request.CommentId &&
               postComment.UserId == request.UserId &&
               postComment.Content == request.Body.Content;
    }

    public static bool IsSatisfied(this PostComment postComment, PostComment p)
    {
        return postComment.Id == p.Id &&
               postComment.CommentId == p.CommentId &&
               postComment.UserId == p.UserId &&
               postComment.Content == p.Content &&
               postComment.CreatedAt == p.CreatedAt &&
               postComment.UpdatedAt == p.UpdatedAt;
    }

    public static bool IsSatisfied(this GetAllPostCommentsQueryRequest request, GetAllPostCommentsApiRequest r)
    {
        return request.Filter.Id == r.Filter.Id &&
               request.Filter.UserId == r.Filter.UserId &&
               request.Filter.UserName == r.Filter.UserName &&
               request.Pagination.Page == r.Pagination.Page &&
               request.Pagination.PageSize == r.Pagination.PageSize &&
               request.Sorting.Order == r.Sorting.Order &&
               request.Sorting.Property == r.Sorting.Property;
    }

    public static bool IsSatisfied(this GetPostCommentByIdQueryRequest request, GetPostCommentByIdApiRequest r)
    {
        return request.Id == r.Id &&
               request.CommentId == r.CommentId;
    }

    public static bool IsSatisfied(this AddPostCommentCommandRequest request, AddPostCommentApiRequest r)
    {
        return request.Id == r.Id &&
               request.Content == r.Body.Content &&
               request.UserId == r.UserId;
    }

    public static bool IsSatisfied(this UpdatePostCommentCommandRequest request, UpdatePostCommentApiRequest r)
    {
        return request.Id == r.Id &&
               request.CommentId == r.CommentId &&
               request.Content == r.Body.Content &&
               request.UserId == r.UserId;
    }

    public static bool IsSatisfied(this DeletePostCommentCommandRequest request, DeletePostCommentApiRequest r)
    {
        return request.Id == r.Id &&
               request.UserId == r.UserId;
    }

    public static bool IsSatisfied(this GetAllPostCommentsQuery query, GetAllPostCommentsQueryRequest request)
    {
        return query.Filter.Id == request.Filter.Id &&
               query.Filter.UserId == request.Filter.UserId &&
               query.Filter.UserName == request.Filter.UserName &&
               query.Pagination.Page == request.Pagination.Page &&
               query.Pagination.PageSize == request.Pagination.PageSize &&
               query.Sorting.Order == request.Sorting.Order &&
               query.Sorting.Property == request.Sorting.Property;
    }

    public static bool IsSatisfied(this GetPostCommentByIdQuery query, GetPostCommentByIdQueryRequest request)
    {
        return query.Id == request.Id &&
               query.CommentId == request.CommentId;
    }

    public static bool IsSatisfied(this AddPostCommentCommand command, AddPostCommentCommandRequest request)
    {
        return command.Id == request.Id &&
               command.Content == request.Content &&
               command.UserId == request.UserId;
    }

    public static bool IsSatisfied(this UpdatePostCommentCommand command, UpdatePostCommentCommandRequest expected)
    {
        return command.Id == expected.Id &&
               command.CommentId == expected.CommentId &&
               command.Content == expected.Content &&
               command.UserId == expected.UserId;
    }

    public static bool IsSatisfied(this DeletePostCommentCommand command, DeletePostCommentCommandRequest request)
    {
        return command.Id == request.Id &&
               command.CommentId == request.CommentId &&
               command.UserId == request.UserId;
    }

    public static bool IsSatisfied(this PostCommentAddedEvent addedEvent, PostComment postComment)
    {
        return addedEvent.Id == postComment.Id &&
               addedEvent.CommentId == postComment.CommentId &&
               addedEvent.Content == postComment.Content &&
               addedEvent.UserId == postComment.UserId &&
               addedEvent.CreatedAt == postComment.CreatedAt &&
               addedEvent.UpdatedAt == postComment.UpdatedAt;
    }

    public static bool IsSatisfied(this PostCommentUpdatedEvent updatedEvent, PostComment postComment)
    {
        return updatedEvent.Id == postComment.Id &&
               updatedEvent.CommentId == postComment.CommentId &&
               updatedEvent.Content == postComment.Content &&
               updatedEvent.UserId == postComment.UserId &&
               updatedEvent.CreatedAt == postComment.CreatedAt &&
               updatedEvent.UpdatedAt == postComment.UpdatedAt;
    }

    public static bool IsSatisfied(this PostCommentDeletedEvent deletedEvent, PostComment postComment)
    {
        return deletedEvent.Id == postComment.Id &&
               deletedEvent.CommentId == postComment.CommentId;
    }
}
