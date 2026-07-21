using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMatchAssertions
{
	extension(EmailConfirmationTokenId response)
	{
		public void ShouldSatisfy(AddEmailConfirmationTokenCommand command, EmailConfirmationToken emailConfirmationToken)
		{
			response.ShouldSatisfy(p => p.Matches(command, emailConfirmationToken));
		}
	}

	extension(User user)
	{
		public void ShouldSatisfy(VerifyEmailConfirmationTokenCommand command)
		{
			user.ShouldSatisfy(p => p.Matches(command));
		}
	}
}
