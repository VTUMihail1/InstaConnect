using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		public UserId ToId(
)
		{
			return user.Id;
		}

		public User ToEntity(
)
		{
			var cloneUser = new User(
				user.Id,
				user.FirstName,
				user.LastName,
				new(user.Email.Value),
				new(user.Name.Value),
				user.PasswordHash,
				user.IsEmailConfirmed,
				new(user.ProfileImage?.Url),
				user.CreatedAtUtc,
				user.UpdatedAtUtc);

			foreach(var ect in user.EmailConfirmationTokens)
			{
				var emailConfirmationToken = new EmailConfirmationToken(ect.Id, ect.ExpiresAtUtc, ect.CreatedAtUtc).AddUser(cloneUser);
				cloneUser.AddEmailConfirmationToken(emailConfirmationToken);
			}

			return cloneUser;
		}
	}
}
