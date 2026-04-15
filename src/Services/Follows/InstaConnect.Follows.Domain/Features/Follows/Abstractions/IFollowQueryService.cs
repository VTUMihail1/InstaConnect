namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowQueryService
{
    public Task<FollowCollectionResponse> GetAllAsync(GetAllFollowsQuery query, CancellationToken cancellationToken);

    public Task<FollowCollectionResponse> GetAllForFollowingAsync(GetAllFollowsForFollowingQuery query, CancellationToken cancellationToken);

    public Task<FollowResponse> GetByIdAsync(GetFollowByIdQuery query, CancellationToken cancellationToken);
}
