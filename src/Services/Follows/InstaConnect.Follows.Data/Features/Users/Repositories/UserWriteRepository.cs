using InstaConnect.Follows.Data.Features.Users.Abstractions;
using InstaConnect.Follows.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Follows.Data.Features.Users.Repositories;

internal class UserWriteRepository : BaseWriteRepository<User>, IUserWriteRepository
{
    public UserWriteRepository(FollowsContext followsContext) : base(followsContext)
    {
    }
}
