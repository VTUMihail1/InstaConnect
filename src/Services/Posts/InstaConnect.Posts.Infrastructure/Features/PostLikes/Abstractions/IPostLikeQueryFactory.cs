using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Models;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;
public interface IPostLikeQueryFactory
{
    GetAllPostLikesQuerySpecification CreateGetAll(GetAllPostLikesQuery query);

    GetAllPostLikesTotalCountQuerySpecification CreateGetAllTotalCount(PostLikeFilterQuery query);

    GetPostLikeByIdQuerySpecification CreateGetById(string id, string userId);
}
