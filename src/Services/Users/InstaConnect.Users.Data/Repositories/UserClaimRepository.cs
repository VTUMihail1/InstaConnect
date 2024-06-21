using InstaConnect.Shared.Data;
using InstaConnect.Shared.Data.Repositories;
using InstaConnect.Users.Data.Abstraction;
using InstaConnect.Users.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Users.Data.Repositories;

internal class UserClaimRepository : BaseRepository<UserClaim>, IUserClaimRepository
{
    private readonly UsersContext _usersContext;

    public UserClaimRepository(UsersContext usersContext) : base(usersContext)
    {
        _usersContext = usersContext;
    }
}
