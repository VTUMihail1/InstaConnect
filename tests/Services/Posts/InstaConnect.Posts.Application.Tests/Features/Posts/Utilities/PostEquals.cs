using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostEquals
{
    public static bool Matches(this GetAllPostsQuery query, GetAllPostsQueryRequest request)
    {
        return query.Filter.UserId.Matches(request.UserId) &&
               query.Filter.UserName.Matches(request.UserName) &&
               query.Filter.Title == request.Title &&
               query.Pagination.Page == request.Page &&
               query.Pagination.PageSize == request.PageSize &&
               query.Sorting.Order == request.SortOrder &&
               query.Sorting.Property == request.SortProperty &&
               query.Include!.Properties.All(a => a == PostIncludeProperty.User);
    }

    public static bool Matches(this GetPostByIdQuery query, GetPostByIdQueryRequest request)
    {
        return query.Id.Matches(request.Id) &&
               query.Include!.Properties.All(a => a == PostIncludeProperty.User);
    }

    public static bool Matches(this AddPostCommand command, AddPostCommandRequest request)
    {
        return command.UserId.Matches(request.UserId) &&
               command.Title == request.Title &&
               command.Content == request.Content;
    }

    public static bool Matches(this UpdatePostCommand command, UpdatePostCommandRequest request)
    {
        return command.Id.Matches(request.Id) &&
               command.UserId.Matches(request.UserId) &&
               command.Title == request.Title &&
               command.Content == request.Content;
    }

    public static bool Matches(this DeletePostCommand command, DeletePostCommandRequest request)
    {
        return command.Id.Matches(request.Id) &&
               command.UserId.Matches(request.UserId);
    }

    public static bool Matches(this AddPostCommandResponse response, Post post)
    {
        return response.Response.Matches(post.Id);
    }

    public static bool Matches(this UpdatePostCommandResponse response, Post post)
    {
        return response.Response.Matches(post.Id);
    }

    public static bool Matches(this GetPostByIdQueryResponse response, Post post, User user)
    {
        return response.Response.Matches(post, user);
    }

    public static bool Matches(this GetAllPostsQueryResponse response, Post post, User user, GetAllPostsQueryRequest request)
    {
        return response.Response.Entities.All(p => p.Matches(post, user)) &&
               response.Response.Page == request.Page &&
               response.Response.PageSize == request.PageSize &&
               response.Response.TotalCount == response.Response.Entities.Count &&
               response.Response.HasPreviousPage == response.Response.Page > 1 &&
               response.Response.HasNextPage == response.Response.Page * response.Response.PageSize < response.Response.TotalCount;
    }

    public static bool Matches(this Post post, AddPostCommandRequest request)
    {
        return post.UserId.Matches(request.UserId) &&
               post.Title == request.Title &&
               post.Content == request.Content;
    }

    public static bool Matches(this Post post, UpdatePostCommandRequest request)
    {
        return post.Id.Matches(request.Id) &&
               post.UserId.Matches(request.UserId) &&
               post.Title == request.Title &&
               post.Content == request.Content;
    }

    public static bool Matches(this PostIdCommandResponse response, PostId id)
    {
        return id.Matches(response.Id);
    }

    public static bool Matches(this PostQueryResponse response, Post post, User user)
    {
        return post.Id.Matches(response.Id) &&
               post.Title == response.Title &&
               post.Content == response.Content &&
               response.User.Matches(user) &&
               post.CreatedAtUtc == response.CreatedAtUtc &&
               post.UpdatedAtUtc == response.UpdatedAtUtc;
    }
}
