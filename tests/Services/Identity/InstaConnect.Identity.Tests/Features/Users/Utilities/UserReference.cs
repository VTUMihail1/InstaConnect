using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Domain.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserReference
{
	extension(User? user)
	{
		public User? SetUserClaims()
		{
			user?.UserClaims.AddUser(user);

			return user;
		}

		public User? SetRefreshTokens()
		{
			user?.RefreshTokens.AddUser(user);

			return user;
		}

		public User? SetForgotPasswordTokens()
		{
			user?.ForgotPasswordTokens.AddUser(user);

			return user;
		}

		public User? SetEmailConfirmationTokens()
		{
			user?.EmailConfirmationTokens.AddUser(user);

			return user;
		}
	}
}
