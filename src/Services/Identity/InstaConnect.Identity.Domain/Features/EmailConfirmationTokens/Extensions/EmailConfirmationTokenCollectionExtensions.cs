namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Extensions;

public static class EmailConfirmationTokenCollectionExtensions
{
	extension(ICollection<EmailConfirmationToken> emailConfirmationTokens)
	{
		public ICollection<EmailConfirmationToken> AddUser(User user)
		{
			foreach (var emailConfirmationToken in emailConfirmationTokens)
			{
				emailConfirmationToken.AddUser(user);
			}

			return emailConfirmationTokens;
		}
	}
}
