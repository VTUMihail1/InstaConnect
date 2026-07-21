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

	extension(User user)
	{
		public void ShouldSatisfy(VerifyEmailConfirmationTokenApiRequest request)
		{
			user.ShouldSatisfy(p => p.Matches(request));
		}
	}
}
