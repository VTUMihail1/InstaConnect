using InstaConnect.Identity.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includers;

internal class ForgotPasswordTokensIncluder : IUserIncluder
{
    private readonly IIdentityContext _context;

    public ForgotPasswordTokensIncluder(IIdentityContext context)
    {
        _context = context;
    }

    public IdentityDestinationType DestinationType => IdentityDestinationType.User;

    public IdentityIncludeType IncludeType => IdentityIncludeType.ForgotPasswordToken;

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
