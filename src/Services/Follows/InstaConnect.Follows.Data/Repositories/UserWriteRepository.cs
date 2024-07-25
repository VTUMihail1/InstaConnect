using InstaConnect.Follows.Data.Abstractions;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Follows.Data.Repositories;

internal class UserWriteRepository : BaseWriteRepository<User>, IUserWriteRepository
{
    public UserWriteRepository(FollowsContext followsContext) : base(followsContext)
    {
    }
}
