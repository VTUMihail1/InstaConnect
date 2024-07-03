using InstaConnect.Follows.Read.Data.Abstractions;
using InstaConnect.Follows.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Follows.Read.Data.Repositories;

internal class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly FollowsContext _followsContext;

    public UserRepository(FollowsContext followsContext) : base(followsContext)
    {
        _followsContext = followsContext;
    }
}
