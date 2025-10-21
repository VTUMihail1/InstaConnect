using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.RefreshTokens.Application.Features.RefreshTokens.Mappings;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Infrastructure.Abstractions;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;

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
                l => l.Id,
                p => p.Claims
            );
    }
}
