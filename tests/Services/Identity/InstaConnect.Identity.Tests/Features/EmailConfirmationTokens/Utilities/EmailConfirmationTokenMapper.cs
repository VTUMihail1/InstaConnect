using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenMapper
{
	extension(EmailConfirmationToken emailConfirmationToken)
	{
		public EmailConfirmationTokenId ToId(
)
		{
			return emailConfirmationToken.Id;
		}

		public EmailConfirmationToken ToFull()
		{
			return new EmailConfirmationToken(emailConfirmationToken.Id,
					   emailConfirmationToken.ExpiresAtUtc,
					   emailConfirmationToken.CreatedAtUtc)
				.AddUser(emailConfirmationToken.User?.ToFull());
		}

		public EmailConfirmationToken ToWithoutUser()
		{
			return new(emailConfirmationToken.Id,
					   emailConfirmationToken.ExpiresAtUtc,
					   emailConfirmationToken.CreatedAtUtc);
		}
	}
}
