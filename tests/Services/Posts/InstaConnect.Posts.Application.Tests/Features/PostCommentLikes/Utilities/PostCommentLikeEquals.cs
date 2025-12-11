using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
    public static bool Matches(this GetAllPostCommentLikesQuery query, GetAllPostCommentLikesQueryRequest request)
    {
        return query.Filter.CommentId.Matches(request.Id, request.CommentId) &&
               query.Filter.UserName.Matches(request.UserName) &&
               query.Pagination.Page == request.Page &&
               query.Pagination.PageSize == request.PageSize &&
               query.Sorting.Order == request.SortOrder &&
               query.Sorting.Property == request.SortProperty &&
               query.Include!.Properties.All(a => a == PostCommentLikeIncludeProperty.User);
    }

    public static bool Matches(this GetPostCommentLikeByIdQuery query, GetPostCommentLikeByIdQueryRequest request)
    {
        return query.Id.Matches(request.Id, request.CommentId, request.UserId) &&
               query.Include!.Properties.All(a => a == PostCommentLikeIncludeProperty.User);
    }

    public static bool Matches(this AddPostCommentLikeCommand command, AddPostCommentLikeCommandRequest request)
    {
        return command.CommentId.Matches(request.Id, request.CommentId) &&
               command.UserId.Matches(request.UserId);
    }

    public static bool Matches(this DeletePostCommentLikeCommand command, DeletePostCommentLikeCommandRequest request)
    {
        return command.Id.Matches(request.Id, request.CommentId, request.UserId);
    }

    public static bool Matches(this AddPostCommentLikeCommandResponse response, PostCommentLike postCommentLike)
    {
        return response.Response.Matches(postCommentLike.Id);
    }

    public static bool Matches(this GetPostCommentLikeByIdQueryResponse response, PostCommentLike postCommentLike, User user)
    {
        return response.Response.Matches(postCommentLike, user);
    }

    public static bool Matches(this GetAllPostCommentLikesQueryResponse response, PostCommentLike postCommentLike, User user, GetAllPostCommentLikesQueryRequest request)
    {
        return response.Response.Entities.All(p => p.Matches(postCommentLike, user)) &&
               response.Response.Page == request.Page &&
               response.Response.PageSize == request.PageSize &&
               response.Response.TotalCount == response.Response.Entities.Count &&
               response.Response.HasPreviousPage == response.Response.Page > 1 &&
               response.Response.HasNextPage == response.Response.Page * response.Response.PageSize < response.Response.TotalCount;
    }

    public static bool Matches(this PostCommentLike postCommentLike, AddPostCommentLikeCommandRequest request)
    {
        return postCommentLike.Id.Matches(request.Id, request.CommentId, request.UserId);
    }

    public static bool Matches(this PostCommentLikeIdCommandResponse response, PostCommentLikeId id)
    {
        return id.Matches(response.Id, response.CommentId, response.UserId);
    }

    public static bool Matches(this PostCommentLikeQueryResponse response, PostCommentLike postCommentLike, User user)
    {
        return postCommentLike.Id.Matches(response.Id, response.CommentId, response.User.Id) &&
               response.User.Matches(user) &&
               response.CreatedAtUtc == postCommentLike.CreatedAtUtc;
    }
}
