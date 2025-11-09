namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;
public interface IFollowService
{
    public Task<FollowCollection> GetAllByFollowerAsync(GetAllFollowsByFollowerQuery query, CancellationToken cancellationToken);

    public Task<FollowCollection> GetAllByFollowingAsync(GetAllFollowsByFollowingQuery query, CancellationToken cancellationToken);

    public Task<Follow> GetByIdAsync(GetFollowByIdQuery query, CancellationToken cancellationToken);

    public Task<Follow> AddAsync(AddFollowCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeleteFollowCommand command, CancellationToken cancellationToken);
}
