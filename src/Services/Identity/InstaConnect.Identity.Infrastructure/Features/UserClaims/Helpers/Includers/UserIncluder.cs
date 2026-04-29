using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Includers;

internal class UserIncluder : IUserClaimIncluder
{
	private readonly IIdentityContext _context;

	public UserIncluder(IIdentityContext context)
	{
		_context = context;
	}

	public IdentityDestinationType DestinationType => IdentityDestinationType.UserClaim;

	public IdentityIncludeType IncludeType => IdentityIncludeType.User;

	public IAggregateFluent<UserClaim> Include(IAggregateFluent<UserClaim> aggregate)
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
