using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserReference
{
	extension(User? user)
	{
		public User? SetUserClaims()
		{
			user?.UserClaims.ForEach(e => e.AddUser(user));

			return user;
		}

		public User? SetRefreshTokens()
		{
			user?.RefreshTokens.ForEach(e => e.AddUser(user));

			return user;
		}

		public User? SetForgotPasswordTokens()
		{
			user?.ForgotPasswordTokens.ForEach(e => e.AddUser(user));

			return user;
		}

		public User? SetEmailConfirmationTokens()
		{
			user?.EmailConfirmationTokens.ForEach(e => e.AddUser(user));

			return user;
		}
	}
}
