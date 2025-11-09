using InstaConnect.Identity.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includes;

public class UserRefreshTokensIncludeProperty : IUserIncludeProperty
{
    private readonly IIdentityContext _usersContext;

    public UserRefreshTokensIncludeProperty(IIdentityContext usersContext)
    {
        _usersContext = usersContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.RefreshTokens;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .Lookup<User, RefreshToken, User>(
                _usersContext.RefreshTokens,
                p => p.Id,
                l => l.Id,
                p => p.RefreshTokens
            );
    }
}
