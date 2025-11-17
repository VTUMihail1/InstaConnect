using InstaConnect.Identity.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includes;

public class UserClaimsIncludeProperty : IUserIncludeProperty
{
    private readonly IIdentityContext _usersContext;

    public UserClaimsIncludeProperty(IIdentityContext usersContext)
    {
        _usersContext = usersContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.Claims;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .Lookup<User, UserClaim, User>(
                _usersContext.UserClaims,
                p => p.Id,
                l => l.Id.Id,
                p => p.Claims
            );
    }
}
