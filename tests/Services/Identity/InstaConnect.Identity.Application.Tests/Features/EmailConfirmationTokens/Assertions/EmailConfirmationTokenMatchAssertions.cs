using InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMatchAssertions
{
	extension(EmailConfirmationToken emailConfirmationToken)
	{
		public void ShouldSatisfy(AddEmailConfirmationTokenCommandRequest request)
		{
			emailConfirmationToken.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(VerifyEmailConfirmationTokenCommandRequest request)
		{
			emailConfirmationToken.ShouldSatisfy(p => p.Matches(request));
		}
	}
}
