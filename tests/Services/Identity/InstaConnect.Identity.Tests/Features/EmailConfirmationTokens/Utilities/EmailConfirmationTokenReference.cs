namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenReference
{
	extension(EmailConfirmationToken? emailConfirmationToken)
	{
		public EmailConfirmationToken? SetUser()
		{
			emailConfirmationToken?.User?.AddEmailConfirmationToken(emailConfirmationToken);

			return emailConfirmationToken;
		}
	}
}
