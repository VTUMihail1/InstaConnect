using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Infrastructure.Abstractions;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;

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
