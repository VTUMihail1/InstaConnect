namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Extensions;

public static class ForgotPasswordTokenCollectionExtensions
{
	extension(ICollection<ForgotPasswordToken> forgotPasswordTokens)
	{
		public ICollection<ForgotPasswordToken> AddUser(User user)
		{
			foreach (var forgotPasswordToken in forgotPasswordTokens)
			{
				forgotPasswordToken.AddUser(user);
			}

			return forgotPasswordTokens;
		}
	}
}
