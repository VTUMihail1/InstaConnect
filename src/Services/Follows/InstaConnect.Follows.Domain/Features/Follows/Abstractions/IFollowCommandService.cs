namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowCommandService
{
    public Task<FollowId> AddAsync(AddFollowCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeleteFollowCommand command, CancellationToken cancellationToken);
}
