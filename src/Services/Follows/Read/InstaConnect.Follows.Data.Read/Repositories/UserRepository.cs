using InstaConnect.Follows.Data.Read.Abstractions;
using InstaConnect.Follows.Data.Read.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Follows.Data.Read.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly FollowsContext _followsContext;

    public UserRepository(FollowsContext followsContext) : base(followsContext)
    {
        _followsContext = followsContext;
    }
}
