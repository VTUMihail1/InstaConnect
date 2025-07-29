using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
public interface IPostQueryFactory
{
    GetAllPostsQuerySpecification CreateGetAll(GetAllPostsQuery query);
    GetAllPostsTotalCountQuerySpecification CreateGetAllTotalCount(PostFilterQuery query);
    GetPostByIdQuerySpecification CreateGetById(string id);
}
