using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Models;

namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;
public interface IPostCommentQueryFactory
{
    GetAllPostCommentsQuerySpecification CreateGetAll(GetAllPostCommentsQuery query);

    GetAllPostCommentsTotalCountQuerySpecification CreateGetAllTotalCount(PostCommentFilterQuery query);

    GetPostCommentByIdQuerySpecification CreateGetById(string id, string commentId);
}
