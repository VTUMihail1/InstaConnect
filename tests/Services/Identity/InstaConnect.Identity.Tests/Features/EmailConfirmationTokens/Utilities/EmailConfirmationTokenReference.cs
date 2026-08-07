namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenReference
{
	extension(ICollection<EmailConfirmationToken> emailConfirmationTokens)
	{
		public ICollection<EmailConfirmationToken> SetUser()
		{
			foreach (var emailConfirmationToken in emailConfirmationTokens)
			{
				emailConfirmationToken.SetUser();
			}

			return emailConfirmationTokens;
		}
	}

	extension(EmailConfirmationToken? emailConfirmationToken)
	{
		public EmailConfirmationToken? SetUser()
		{
			emailConfirmationToken?.User?.AddEmailConfirmationToken(emailConfirmationToken);

			return emailConfirmationToken;
		}
	}
}
