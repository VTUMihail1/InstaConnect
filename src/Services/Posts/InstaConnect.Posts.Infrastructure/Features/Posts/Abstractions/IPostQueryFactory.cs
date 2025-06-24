using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
public interface IPostQueryFactory
{
    GetAllQuerySpecification CreateGetAll(GetAllPostsRequest queryParameters);
    GetAllTotalCountQuerySpecification CreateGetAllTotalCount(PostFilterRequest filter);
    GetPostByIdSpecification CreateGetById(string id);
}
