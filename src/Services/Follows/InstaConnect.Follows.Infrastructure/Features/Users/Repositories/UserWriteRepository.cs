namespace InstaConnect.Follows.Infrastructure.Features.Users.Repositories;

internal class UserWriteRepository : IUserWriteRepository
{
    private readonly FollowsContext _followsContext;

    public UserWriteRepository(FollowsContext followsContext)
    {
        _followsContext = followsContext;
    }

    public async Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var user = await _followsContext
            .Users
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return user;
    }

    public void Add(User user)
    {
        _followsContext
            .Users
            .Add(user);
    }

    public void Update(User user)
    {
        _followsContext
            .Users
            .Update(user);
    }

    public void Delete(User user)
    {
        _followsContext
            .Users
            .Remove(user);
    }
}
