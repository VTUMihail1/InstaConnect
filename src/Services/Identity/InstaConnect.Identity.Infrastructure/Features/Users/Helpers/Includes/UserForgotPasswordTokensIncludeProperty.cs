using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Infrastructure.Abstractions;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class UserForgotPasswordTokensIncludeProperty : IUserIncludeProperty
{
    private readonly IIdentityContext _usersContext;

    public UserForgotPasswordTokensIncludeProperty(IIdentityContext usersContext)
    {
        _usersContext = usersContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.ForgotPasswordTokens;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .Lookup<User, ForgotPasswordToken, User>(
                _usersContext.ForgotPasswordTokens,
                p => p.Id,
                l => l.Id,
                p => p.ForgotPasswordTokens
            );
    }
}
