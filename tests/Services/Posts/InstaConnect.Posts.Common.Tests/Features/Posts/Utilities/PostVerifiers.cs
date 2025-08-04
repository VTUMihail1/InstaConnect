using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Models.Events;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

public static class PostVerifiers
{
    public static bool IsSatisfied(this PostQueryResponse response, Post post, User user)
    {
        return response.Id == post.Id &&
               response.Title == post.Title &&
               response.Content == post.Content &&
               response.User.Id == user.Id &&
               response.User.Name == user.Name &&
               response.User.ProfileImage == user.ProfileImage;
    }

    public static bool IsSatisfied(this PostApiResponse response, Post post, User user)
    {
        return response.Id == post.Id &&
               response.Title == post.Title &&
               response.Content == post.Content &&
               response.User.Id == user.Id &&
               response.User.Name == user.Name &&
               response.User.ProfileImage == user.ProfileImage;
    }
    public static bool IsSatisfied(this AddPostCommandResponse response, Post post)
    {
        return response.Id == post.Id &&
               response.CreatedAt == post.CreatedAt &&
               response.UpdatedAt == post.UpdatedAt;
    }

    public static bool IsSatisfied(this UpdatePostCommandResponse response, Post post)
    {
        return response.Id == post.Id &&
               response.CreatedAt == post.CreatedAt &&
               response.UpdatedAt == post.UpdatedAt;
    }

    public static bool IsSatisfied(this GetPostByIdQueryResponse response, Post post, User user)
    {
        return response.Data.IsSatisfied(post, user);
    }

    public static bool IsSatisfied(this GetAllPostsQueryResponse response, Post post, User user, GetAllPostsQueryRequest request)
    {
        return response.Data.All(p => p.IsSatisfied(post, user)) &&
               response.Page == request.Pagination.Page &&
               response.PageSize == request.Pagination.PageSize &&
               response.TotalCount == response.Data.Count &&
               response.HasPreviousPage == response.Page > 1 &&
               response.HasNextPage == response.Page * response.PageSize < response.TotalCount;
    }

    public static bool IsSatisfied(this AddPostApiResponse response, Post post)
    {
        return response.Id == post.Id &&
               response.CreatedAt == post.CreatedAt &&
               response.UpdatedAt == post.UpdatedAt;
    }

    public static bool IsSatisfied(this UpdatePostApiResponse response, Post post)
    {
        return response.Id == post.Id &&
               response.CreatedAt == post.CreatedAt &&
               response.UpdatedAt == post.UpdatedAt;
    }

    public static bool IsSatisfied(this GetPostByIdApiResponse response, Post post, User user)
    {
        return response.Data.IsSatisfied(post, user);
    }

    public static bool IsSatisfied(this GetAllPostsApiResponse response, Post post, User user, GetAllPostsApiRequest request)
    {
        return response.Data.All(p => p.IsSatisfied(post, user)) &&
               response.Page == request.Pagination.Page &&
               response.PageSize == request.Pagination.PageSize &&
               response.TotalCount == response.Data.Count &&
               response.HasPreviousPage == response.Page > 1 &&
               response.HasNextPage == response.Page * response.PageSize < response.TotalCount;
    }

    public static bool IsSatisfied(this Post post, AddPostCommandRequest request)
    {
        return post.UserId == request.UserId &&
               post.Title == request.Title &&
               post.Content == request.Content;
    }

    public static bool IsSatisfied(this Post post, UpdatePostCommandRequest request)
    {
        return post.Id == request.Id &&
               post.UserId == request.UserId &&
               post.Title == request.Title &&
               post.Content == request.Content;
    }

    public static bool IsSatisfied(this Post post, AddPostApiRequest request)
    {
        return post.UserId == request.UserId &&
               post.Title == request.Body.Title &&
               post.Content == request.Body.Content;
    }

    public static bool IsSatisfied(this Post post, UpdatePostApiRequest request)
    {
        return post.Id == request.Id &&
               post.UserId == request.UserId &&
               post.Title == request.Body.Title &&
               post.Content == request.Body.Content;
    }

    public static bool IsSatisfied(this Post post, Post p)
    {
        return post.Id == p.Id &&
               post.UserId == p.UserId &&
               post.Title == p.Title &&
               post.Content == p.Content &&
               post.CreatedAt == p.CreatedAt &&
               post.UpdatedAt == p.UpdatedAt;
    }

    public static bool IsSatisfied(this GetAllPostsQueryRequest request, GetAllPostsApiRequest r)
    {
        return request.Filter.UserId == r.Filter.UserId &&
               request.Filter.UserName == r.Filter.UserName &&
               request.Filter.Title == r.Filter.Title &&
               request.Pagination.Page == r.Pagination.Page &&
               request.Pagination.PageSize == r.Pagination.PageSize &&
               request.Sorting.Order == r.Sorting.Order &&
               request.Sorting.Property == r.Sorting.Property;
    }

    public static bool IsSatisfied(this GetPostByIdQueryRequest request, GetPostByIdApiRequest r)
    {
        return request.Id == r.Id;
    }

    public static bool IsSatisfied(this AddPostCommandRequest request, AddPostApiRequest r)
    {
        return request.Title == r.Body.Title &&
               request.Content == r.Body.Content &&
               request.UserId == r.UserId;
    }

    public static bool IsSatisfied(this UpdatePostCommandRequest request, UpdatePostApiRequest r)
    {
        return request.Id == r.Id &&
               request.Title == r.Body.Title &&
               request.Content == r.Body.Content &&
               request.UserId == r.UserId;
    }

    public static bool IsSatisfied(this DeletePostCommandRequest request, DeletePostApiRequest r)
    {
        return request.Id == r.Id &&
               request.UserId == r.UserId;
    }

    public static bool IsSatisfied(this GetAllPostsQuery query, GetAllPostsQueryRequest request)
    {
        return query.Filter.UserId == request.Filter.UserId &&
               query.Filter.UserName == request.Filter.UserName &&
               query.Filter.Title == request.Filter.Title &&
               query.Pagination.Page == request.Pagination.Page &&
               query.Pagination.PageSize == request.Pagination.PageSize &&
               query.Sorting.Order == request.Sorting.Order &&
               query.Sorting.Property == request.Sorting.Property;
    }

    public static bool IsSatisfied(this GetPostByIdQuery query, GetPostByIdQueryRequest request)
    {
        return query.Id == request.Id;
    }

    public static bool IsSatisfied(this AddPostCommand command, AddPostCommandRequest request)
    {
        return command.Title == request.Title &&
               command.Content == request.Content &&
               command.UserId == request.UserId;
    }

    public static bool IsSatisfied(this UpdatePostCommand command, UpdatePostCommandRequest expected)
    {
        return command.Id == expected.Id &&
               command.Title == expected.Title &&
               command.Content == expected.Content &&
               command.UserId == expected.UserId;
    }

    public static bool IsSatisfied(this DeletePostCommand command, DeletePostCommandRequest request)
    {
        return command.Id == request.Id &&
               command.UserId == request.UserId;
    }

    public static bool IsSatisfied(this PostAddedEvent addedEvent, Post post)
    {
        return addedEvent.Id == post.Id &&
               addedEvent.Title == post.Title &&
               addedEvent.Content == post.Content &&
               addedEvent.UserId == post.UserId &&
               addedEvent.CreatedAt == post.CreatedAt &&
               addedEvent.UpdatedAt == post.UpdatedAt;
    }

    public static bool IsSatisfied(this PostUpdatedEvent updatedEvent, Post post)
    {
        return updatedEvent.Id == post.Id &&
               updatedEvent.Title == post.Title &&
               updatedEvent.Content == post.Content &&
               updatedEvent.UserId == post.UserId &&
               updatedEvent.CreatedAt == post.CreatedAt &&
               updatedEvent.UpdatedAt == post.UpdatedAt;
    }

    public static bool IsSatisfied(this PostDeletedEvent deletedEvent, Post post)
    {
        return deletedEvent.Id == post.Id;
    }
}
