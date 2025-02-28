using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;

namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
public interface IPostCommentReadRepository
{
    Task<PaginationList<PostComment>> GetAllAsync(PostCommentCollectionReadQuery query, CancellationToken cancellationToken);
    Task<PostComment?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
