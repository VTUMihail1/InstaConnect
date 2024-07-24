using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Follows.Data.Abstractions;

public interface IFollowWriteRepository : IBaseWriteRepository<Follow>
{
    Task<Follow?> GetByFollowerIdAndFollowingIdAsync(string followerId, string followingId, CancellationToken cancellationToken);
}
