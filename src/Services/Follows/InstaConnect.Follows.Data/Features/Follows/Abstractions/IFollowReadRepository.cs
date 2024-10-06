using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Follows.Data.Features.Follows.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Follows.Data.Features.Follows.Abstractions;
public interface IFollowReadRepository
{
    Task<PaginationList<Follow>> GetAllAsync(FollowCollectionReadQuery query, CancellationToken cancellationToken);
    Task<Follow?> GetByFollowerIdAndFollowingIdAsync(string followerId, string followingId, CancellationToken cancellationToken);
    Task<Follow?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
