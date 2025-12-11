using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
    public static bool Matches(this GetAllPostLikesQueryRequest query, GetAllPostLikesApiRequest request)
    {
        return query.Id == request.Id &&
               query.UserName == request.UserName &&
               query.Page == request.Page &&
               query.PageSize == request.PageSize &&
               query.SortOrder == request.SortOrder &&
               query.SortProperty == request.SortProperty;
    }

    public static bool Matches(this GetPostLikeByIdQueryRequest query, GetPostLikeByIdApiRequest request)
    {
        return query.Id == request.Id &&
               query.UserId == request.UserId;
    }

    public static bool Matches(this AddPostLikeCommandRequest command, AddPostLikeApiRequest request)
    {
        return command.Id == request.Id &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this DeletePostLikeCommandRequest command, DeletePostLikeApiRequest request)
    {
        return command.Id == request.Id &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this AddPostLikeApiResponse response, PostLike postLike)
    {
        return response.Response.Matches(postLike.Id);
    }

    public static bool Matches(this GetPostLikeByIdApiResponse response, PostLike postLike, User user)
    {
        return response.Response.Matches(postLike, user);
    }

    public static bool Matches(this GetAllPostLikesApiResponse response, PostLike postLike, User user, GetAllPostLikesApiRequest request)
    {
        return response.Response.Entities.All(p => p.Matches(postLike, user)) &&
               response.Response.Page == request.Page &&
               response.Response.PageSize == request.PageSize &&
               response.Response.TotalCount == response.Response.Entities.Count &&
               response.Response.HasPreviousPage == response.Response.Page > 1 &&
               response.Response.HasNextPage == response.Response.Page * response.Response.PageSize < response.Response.TotalCount;
    }

    public static bool Matches(this PostLike postLike, AddPostLikeApiRequest request)
    {
        return postLike.Id.Matches(request.Id, request.UserId);
    }

    public static bool Matches(this PostLikeIdApiResponse response, PostLikeId id)
    {
        return id.Matches(response.Id, response.UserId);
    }

    public static bool Matches(this PostLikeApiResponse response, PostLike postLike, User user)
    {
        return postLike.Id.Matches(response.Id, response.User.Id) &&
               response.User.Matches(user) &&
               response.CreatedAtUtc == postLike.CreatedAtUtc;
    }
}
