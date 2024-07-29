using InstaConnect.Follows.Data.Features.Users.Abstractions;
using InstaConnect.Follows.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Follows.Data.Features.Users.Repositories;

internal class UserReadRepository : BaseReadRepository<User>, IUserReadRepository
{
    public UserReadRepository(FollowsContext followsContext) : base(followsContext)
    {
    }
}
