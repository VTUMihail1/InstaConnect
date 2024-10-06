using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostComments.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Posts.Data.Features.PostComments.Abstract;
public interface IPostCommentReadRepository
{
    Task<PaginationList<PostComment>> GetAllAsync(PostCommentCollectionReadQuery query, CancellationToken cancellationToken);
    Task<PostComment?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
