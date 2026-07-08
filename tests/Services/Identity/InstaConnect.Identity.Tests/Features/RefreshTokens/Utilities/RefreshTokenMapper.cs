using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMapper
{
	extension(RefreshToken refreshToken)
	{
		public RefreshTokenId ToId(
)
		{
			return refreshToken.Id;
		}

		public RefreshToken ToFull()
		{
			return new RefreshToken(refreshToken.Id,
					   refreshToken.ExpiresAtUtc,
					   refreshToken.CreatedAtUtc)
				.AddUser(refreshToken.User?.ToFull());
		}

		public RefreshToken ToWithoutUser()
		{
			return new(refreshToken.Id,
					   refreshToken.ExpiresAtUtc,
					   refreshToken.CreatedAtUtc);
		}
	}
}
