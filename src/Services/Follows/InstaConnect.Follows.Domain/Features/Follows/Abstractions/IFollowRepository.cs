using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowRepository
{
    Task<FollowCollection> GetAllByFollowerAsync(GetAllFollowsByFollowerQuery query, CancellationToken cancellationToken);

    Task<FollowCollection> GetAllByFollowingAsync(GetAllFollowsByFollowingQuery query, CancellationToken cancellationToken);

    Task<Follow?> GetByIdAsync(string followerId, string followingId, CancellationToken cancellationToken);

    void Add(Follow follow);

    void Update(Follow follow);

    void Delete(Follow follow);
}
