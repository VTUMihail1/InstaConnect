using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;

namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;
public interface IFollowReadRepository
{
    Task<PaginationList<Follow>> GetAllAsync(FollowCollectionReadQuery query, CancellationToken cancellationToken);
    Task<Follow?> GetByFollowerIdAndFollowingIdAsync(string followerId, string followingId, CancellationToken cancellationToken);
    Task<Follow?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
