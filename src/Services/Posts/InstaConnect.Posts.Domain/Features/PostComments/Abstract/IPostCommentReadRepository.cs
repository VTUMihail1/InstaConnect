using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;

namespace InstaConnect.Posts.Domain.Features.PostComments.Abstract;
public interface IPostCommentReadRepository
{
    Task<PaginationList<PostComment>> GetAllAsync(PostCommentCollectionReadQuery query, CancellationToken cancellationToken);
    Task<PostComment?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
