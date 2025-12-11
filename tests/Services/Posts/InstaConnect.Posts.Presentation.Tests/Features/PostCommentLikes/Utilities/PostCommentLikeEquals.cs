using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
    public static bool Matches(this GetAllPostCommentLikesQueryRequest query, GetAllPostCommentLikesApiRequest request)
    {
        return query.Id == request.Id &&
               query.CommentId == request.CommentId &&
               query.UserName == request.UserName &&
               query.Page == request.Page &&
               query.PageSize == request.PageSize &&
               query.SortOrder == request.SortOrder &&
               query.SortProperty == request.SortProperty;
    }

    public static bool Matches(this GetPostCommentLikeByIdQueryRequest query, GetPostCommentLikeByIdApiRequest request)
    {
        return query.Id == request.Id &&
               query.CommentId == request.CommentId &&
               query.UserId == request.UserId;
    }

    public static bool Matches(this AddPostCommentLikeCommandRequest command, AddPostCommentLikeApiRequest request)
    {
        return command.Id == request.Id &&
               command.CommentId == request.CommentId &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this DeletePostCommentLikeCommandRequest command, DeletePostCommentLikeApiRequest request)
    {
        return command.Id == request.Id &&
               command.CommentId == request.CommentId &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this AddPostCommentLikeApiResponse response, PostCommentLike postCommentLike)
    {
        return response.Response.Matches(postCommentLike.Id);
    }

    public static bool Matches(this GetPostCommentLikeByIdApiResponse response, PostCommentLike postCommentLike, User user)
    {
        return response.Response.Matches(postCommentLike, user);
    }

    public static bool Matches(this GetAllPostCommentLikesApiResponse response, PostCommentLike postCommentLike, User user, GetAllPostCommentLikesApiRequest request)
    {
        return response.Response.Entities.All(p => p.Matches(postCommentLike, user)) &&
               response.Response.Page == request.Page &&
               response.Response.PageSize == request.PageSize &&
               response.Response.TotalCount == response.Response.Entities.Count &&
               response.Response.HasPreviousPage == response.Response.Page > 1 &&
               response.Response.HasNextPage == response.Response.Page * response.Response.PageSize < response.Response.TotalCount;
    }

    public static bool Matches(this PostCommentLike postCommentLike, AddPostCommentLikeApiRequest request)
    {
        return postCommentLike.Id.Matches(request.Id, request.CommentId, request.UserId);
    }

    public static bool Matches(this PostCommentLikeIdApiResponse response, PostCommentLikeId id)
    {
        return id.Matches(response.Id, response.CommentId, response.UserId);
    }

    public static bool Matches(this PostCommentLikeApiResponse response, PostCommentLike postCommentLike, User user)
    {
        return postCommentLike.Id.Matches(response.Id, response.CommentId, response.User.Id) &&
               response.User.Matches(user) &&
               response.CreatedAtUtc == postCommentLike.CreatedAtUtc;
    }
}
