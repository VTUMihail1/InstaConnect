using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenEquals
{
	extension(RefreshTokenId p)
	{
		public bool Matches(RefreshTokenId id)
		{
			return p.Matches(id.Id.Id, id.Value);
		}

		public bool Matches(string id, string value)
		{
			return p.Id.Matches(id) &&
				   p.Value.EqualsOrdinalIgnoreCase(value);
		}
	}

	extension(RefreshToken entity)
	{
		public bool Matches(RefreshToken e)
		{
			return entity.Id.Matches(e.Id) &&
				   entity.ExpiresAtUtc == e.ExpiresAtUtc &&
				   entity.CreatedAtUtc == e.CreatedAtUtc;
		}
	}
}
