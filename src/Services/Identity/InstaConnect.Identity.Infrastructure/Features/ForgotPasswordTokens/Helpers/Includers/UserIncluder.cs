using InstaConnect.Identity.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Includers;

internal class UserIncluder : IForgotPasswordTokenIncluder
{
    private readonly IIdentityContext _context;

    public UserIncluder(IIdentityContext context)
    {
        _context = context;
    }

    public IdentityDestinationType DestinationType => IdentityDestinationType.ForgotPasswordTokens;

    public IdentityIncludeType IncludeType => IdentityIncludeType.Users;

    public IAggregateFluent<ForgotPasswordToken> Include(IAggregateFluent<ForgotPasswordToken> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Users,
                p => p.Id.Id,
                l => l.Id,
                p => p.User!
            );
    }
}
