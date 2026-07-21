using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMatchAssertions
{
	extension(EmailConfirmationToken u)
	{
		public void ShouldSatisfy(EmailConfirmationToken emailConfirmationToken)
		{
			u.ShouldSatisfy(u => u.Matches(emailConfirmationToken));
		}
	}
}
