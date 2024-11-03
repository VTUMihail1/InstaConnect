using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Data.Features.Posts.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Posts.Data.Features.Posts.Abstract;
public interface IPostReadRepository
{
    Task<PaginationList<Post>> GetAllAsync(PostCollectionReadQuery query, CancellationToken cancellationToken);
    Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
