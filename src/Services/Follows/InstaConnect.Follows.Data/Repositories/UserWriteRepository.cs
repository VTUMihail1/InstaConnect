using InstaConnect.Follows.Data.Abstractions;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Follows.Data.Repositories;

internal class UserWriteRepository : BaseWriteRepository<User>, IUserWriteRepository
{
    private readonly FollowsContext _followsContext;

    public UserWriteRepository(FollowsContext followsContext) : base(followsContext)
    {
        _followsContext = followsContext;
    }
}
