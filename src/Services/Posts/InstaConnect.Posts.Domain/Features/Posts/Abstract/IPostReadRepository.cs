using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Posts.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstract;
public interface IPostReadRepository
{
    Task<PaginationList<Post>> GetAllAsync(PostCollectionReadQuery query, CancellationToken cancellationToken);
    Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
