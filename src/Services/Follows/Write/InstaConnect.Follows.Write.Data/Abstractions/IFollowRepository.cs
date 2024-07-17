using InstaConnect.Follows.Write.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Follows.Write.Data.Abstractions;

public interface IFollowRepository : IBaseReadRepository<Follow>
{
    Task<Follow?> GetByFollowerIdAndFollowingIdAsync(string followerId, string followingId, CancellationToken cancellationToken);
}
