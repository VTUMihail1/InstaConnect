using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostEquals
{
    public static bool Matches(this GetAllPostsQueryRequest query, GetAllPostsApiRequest request)
    {
        return query.UserId == request.UserId &&
               query.UserName == request.UserName &&
               query.Title == request.Title &&
               query.Page == request.Page &&
               query.PageSize == request.PageSize &&
               query.SortOrder == request.SortOrder &&
               query.SortProperty == request.SortProperty;
    }

    public static bool Matches(this GetPostByIdQueryRequest query, GetPostByIdApiRequest request)
    {
        return query.Id == request.Id;
    }

    public static bool Matches(this AddPostCommandRequest command, AddPostApiRequest request)
    {
        return command.Title == request.Body.Title &&
               command.Content == request.Body.Content &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this UpdatePostCommandRequest command, UpdatePostApiRequest request)
    {
        return command.Id == request.Id &&
               command.Title == request.Body.Title &&
               command.Content == request.Body.Content &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this DeletePostCommandRequest command, DeletePostApiRequest request)
    {
        return command.Id == request.Id &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this AddPostApiResponse response, Post post)
    {
        return response.Response.Matches(post.Id);
    }

    public static bool Matches(this UpdatePostApiResponse response, Post post)
    {
        return response.Response.Matches(post.Id);
    }

    public static bool Matches(this GetPostByIdApiResponse response, Post post, User user)
    {
        return response.Response.Matches(post, user);
    }

    public static bool Matches(this GetAllPostsApiResponse response, Post post, User user, GetAllPostsApiRequest request)
    {
        return response.Response.Entities.All(p => p.Matches(post, user)) &&
               response.Response.Page == request.Page &&
               response.Response.PageSize == request.PageSize &&
               response.Response.TotalCount == response.Response.Entities.Count &&
               response.Response.HasPreviousPage == response.Response.Page > 1 &&
               response.Response.HasNextPage == response.Response.Page * response.Response.PageSize < response.Response.TotalCount;
    }

    public static bool Matches(this Post post, AddPostApiRequest request)
    {
        return post.UserId.Matches(request.UserId) &&
               post.Title == request.Body.Title &&
               post.Content == request.Body.Content;
    }

    public static bool Matches(this Post post, UpdatePostApiRequest request)
    {
        return post.Id.Matches(request.Id) &&
               post.UserId.Matches(request.UserId) &&
               post.Title == request.Body.Title &&
               post.Content == request.Body.Content;
    }

    public static bool Matches(this PostIdApiResponse response, PostId id)
    {
        return id.Matches(response.Id);
    }

    public static bool Matches(this PostApiResponse response, Post post, User user)
    {
        return post.Id.Matches(response.Id) &&
               post.Title == response.Title &&
               post.Content == response.Content &&
               response.User.Matches(user) &&
               post.CreatedAtUtc == response.CreatedAtUtc &&
               post.UpdatedAtUtc == response.UpdatedAtUtc;
    }
}
