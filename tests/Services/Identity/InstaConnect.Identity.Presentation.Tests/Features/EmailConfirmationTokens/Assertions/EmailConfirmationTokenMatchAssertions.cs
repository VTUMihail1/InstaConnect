using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMatchAssertions
{
	extension(EmailConfirmationToken emailConfirmationToken)
	{
		public void ShouldSatisfy(AddEmailConfirmationTokenApiRequest request)
		{
			emailConfirmationToken.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(VerifyEmailConfirmationTokenApiRequest request)
		{
			emailConfirmationToken.ShouldSatisfy(p => p.Matches(request));
		}
	}
}
