using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMatchAssertions
{
	extension(EmailConfirmationTokenId response)
	{
		public void ShouldSatisfy(EmailConfirmationToken emailConfirmationToken, AddEmailConfirmationTokenCommand command)
		{
			response.ShouldSatisfy(p => p.Matches(emailConfirmationToken, command));
		}
	}
}
