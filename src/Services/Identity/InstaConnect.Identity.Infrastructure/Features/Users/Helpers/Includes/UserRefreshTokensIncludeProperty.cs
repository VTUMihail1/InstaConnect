using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Infrastructure.Abstractions;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;

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
