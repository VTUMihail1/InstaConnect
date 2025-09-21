using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;

namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;
public interface IPostCommentLikeQueryFactory
{
    GetAllPostCommentLikesQuerySpecification CreateGetAll(GetAllPostCommentLikesQuery query);

    GetAllPostCommentLikesTotalCountQuerySpecification CreateGetAllTotalCount(PostCommentLikeFilterQuery query);

    GetPostCommentLikeByIdSpecification CreateGetById(string id, string commentId, string userId);
}
