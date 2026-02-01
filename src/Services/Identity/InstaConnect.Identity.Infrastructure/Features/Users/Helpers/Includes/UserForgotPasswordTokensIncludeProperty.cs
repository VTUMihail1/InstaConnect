using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includes;

public class UserForgotPasswordTokensIncludeProperty : IUserIncludeProperty
{
    private readonly IIdentityContext _context;

    public UserForgotPasswordTokensIncludeProperty(IIdentityContext context)
    {
        _context = context;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.ForgotPasswordTokens;

    public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.ForgotPasswordTokens,
                p => p.Id,
                l => l.Id.Id,
                p => p.ForgotPasswordTokens
            );
    }
}
