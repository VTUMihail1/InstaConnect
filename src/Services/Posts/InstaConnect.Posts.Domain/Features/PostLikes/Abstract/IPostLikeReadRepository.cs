using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Posts.Data.Features.PostLikes.Abstract;
public interface IPostLikeReadRepository
{
    Task<PaginationList<PostLike>> GetAllAsync(PostLikeCollectionReadQuery query, CancellationToken cancellationToken);
    Task<PostLike?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
