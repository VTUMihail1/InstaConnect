using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
    public static bool Matches(this GetAllPostLikesQuery query, GetAllPostLikesQueryRequest request)
    {
        return query.Filter.Id.Matches(request.Id) &&
               query.Filter.UserName.Matches(request.UserName) &&
               query.Pagination.Page == request.Page &&
               query.Pagination.PageSize == request.PageSize &&
               query.Sorting.Order == request.SortOrder &&
               query.Sorting.Property == request.SortProperty &&
               query.Include!.Properties.All(a => a == PostLikeIncludeProperty.User);
    }

    public static bool Matches(this GetPostLikeByIdQuery query, GetPostLikeByIdQueryRequest request)
    {
        return query.Id.Matches(request.Id, request.UserId) &&
               query.Include!.Properties.All(a => a == PostLikeIncludeProperty.User);
    }

    public static bool Matches(this AddPostLikeCommand command, AddPostLikeCommandRequest request)
    {
        return command.Id.Matches(request.Id) &&
               command.UserId.Matches(request.UserId);
    }

    public static bool Matches(this DeletePostLikeCommand command, DeletePostLikeCommandRequest request)
    {
        return command.Id.Matches(request.Id, request.UserId);
    }

    public static bool Matches(this AddPostLikeCommandResponse response, PostLike postLike)
    {
        return response.Response.Matches(postLike.Id);
    }

    public static bool Matches(this GetPostLikeByIdQueryResponse response, PostLike postLike, User user)
    {
        return response.Response.Matches(postLike, user);
    }

    public static bool Matches(this GetAllPostLikesQueryResponse response, PostLike postLike, User user, GetAllPostLikesQueryRequest request)
    {
        return response.Response.Entities.All(p => p.Matches(postLike, user)) &&
               response.Response.Page == request.Page &&
               response.Response.PageSize == request.PageSize &&
               response.Response.TotalCount == response.Response.Entities.Count &&
               response.Response.HasPreviousPage == response.Response.Page > 1 &&
               response.Response.HasNextPage == response.Response.Page * response.Response.PageSize < response.Response.TotalCount;
    }

    public static bool Matches(this PostLike postLike, AddPostLikeCommandRequest request)
    {
        return postLike.Id.Matches(request.Id, request.UserId);
    }

    public static bool Matches(this PostLikeIdCommandResponse response, PostLikeId id)
    {
        return id.Matches(response.Id, response.UserId);
    }

    public static bool Matches(this PostLikeQueryResponse response, PostLike postLike, User user)
    {
        return postLike.Id.Matches(response.Id, response.User.Id) &&
               response.User.Matches(user) &&
               response.CreatedAtUtc == postLike.CreatedAtUtc;
    }
}
