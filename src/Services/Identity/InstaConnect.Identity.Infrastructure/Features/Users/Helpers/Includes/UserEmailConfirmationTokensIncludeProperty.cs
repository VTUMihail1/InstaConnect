using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includes;

public class UserEmailConfirmationTokensIncludeProperty : IUserIncludeProperty
{
    private readonly IIdentityContext _context;

    public UserEmailConfirmationTokensIncludeProperty(IIdentityContext context)
    {
        _context = context;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.EmailConfirmationTokens;

    public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.EmailConfirmationTokens,
                p => p.Id,
                l => l.Id.Id,
                p => p.EmailConfirmationTokens
            );
    }
}
