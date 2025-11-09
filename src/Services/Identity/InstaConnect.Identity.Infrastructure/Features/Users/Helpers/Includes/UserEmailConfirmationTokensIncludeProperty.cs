using InstaConnect.Identity.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includes;

public class UserEmailConfirmationTokensIncludeProperty : IUserIncludeProperty
{
    private readonly IIdentityContext _usersContext;

    public UserEmailConfirmationTokensIncludeProperty(IIdentityContext usersContext)
    {
        _usersContext = usersContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.EmailConfirmationTokens;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .Lookup<User, EmailConfirmationToken, User>(
                _usersContext.EmailConfirmationTokens,
                p => p.Id,
                l => l.Id,
                p => p.EmailConfirmationTokens
            );
    }
}
