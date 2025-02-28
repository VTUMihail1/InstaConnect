using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
public interface IPostLikeReadRepository
{
    Task<PaginationList<PostLike>> GetAllAsync(PostLikeCollectionReadQuery query, CancellationToken cancellationToken);
    Task<PostLike?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
