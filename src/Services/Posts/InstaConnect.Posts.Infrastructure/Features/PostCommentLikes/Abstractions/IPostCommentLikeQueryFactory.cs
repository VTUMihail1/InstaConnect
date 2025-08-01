using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;

namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;
public interface IPostCommentLikeQueryFactory
{
    GetAllPostCommentLikesQuerySpecification CreateGetAll(GetAllPostCommentLikesQuery query);

    GetAllPostCommentLikesTotalCountQuerySpecification CreateGetAllTotalCount(PostCommentLikeFilterQuery query);

    GetPostCommentLikeByIdQuerySpecification CreateGetById(string id, string commentId, string commentLikeId);

    GetPostCommentLikeByIdAndUserIdQuerySpecification CreateGetByIdAndUserId(string id, string commentId, string userId);
}
