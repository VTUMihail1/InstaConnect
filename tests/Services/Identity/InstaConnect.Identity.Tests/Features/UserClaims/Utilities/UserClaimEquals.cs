using InstaConnect.Common.Events.Features.AccessTokens.Models;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimEquals
{
	extension(UserClaim entity)
	{
		public bool Matches(UserClaim e)
		{
			return entity.Id.Matches(e.Id) &&
				   entity.CreatedAtUtc == e.CreatedAtUtc;
		}
	}

	extension(UserClaimId p)
	{
		public bool Matches(UserClaimId id)
		{
			return p.Matches(id.Id.Id, id.Claim);
		}

		public bool Matches(string id, ApplicationClaims claim)
		{
			return p.Id.Matches(id) &&
				   p.Claim == claim;
		}
	}
}
