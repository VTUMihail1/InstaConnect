using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

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
	}
}
