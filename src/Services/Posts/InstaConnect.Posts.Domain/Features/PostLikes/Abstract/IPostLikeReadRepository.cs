using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstract;
public interface IPostLikeReadRepository
{
    Task<PaginationList<PostLike>> GetAllAsync(PostLikeCollectionReadQuery query, CancellationToken cancellationToken);
    Task<PostLike?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
