using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Follows.Data.Features.Follows.Abstractions;

public interface IFollowReadRepository : IBaseReadRepository<Follow>
{
    Task<Follow?> GetByFollowerIdAndFollowingIdAsync(string followerId, string followingId, CancellationToken cancellationToken);
}
