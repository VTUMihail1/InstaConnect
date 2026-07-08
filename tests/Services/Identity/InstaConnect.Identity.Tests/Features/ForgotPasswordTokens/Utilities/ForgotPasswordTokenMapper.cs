using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMapper
{
	extension(ForgotPasswordToken forgotPasswordToken)
	{
		public ForgotPasswordTokenId ToId(
)
		{
			return forgotPasswordToken.Id;
		}

		public ForgotPasswordToken ToFull()
		{
			return new ForgotPasswordToken(forgotPasswordToken.Id,
					   forgotPasswordToken.ExpiresAtUtc,
					   forgotPasswordToken.CreatedAtUtc)
				.AddUser(forgotPasswordToken.User?.ToFull());
		}

		public ForgotPasswordToken ToWithoutUser()
		{
			return new(forgotPasswordToken.Id,
					   forgotPasswordToken.ExpiresAtUtc,
					   forgotPasswordToken.CreatedAtUtc);
		}
	}
}
