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

		public User ToFull()
		{
			return new(user.Id,
					   user.FirstName,
					   user.LastName,
					   user.Email,
					   user.Name,
					   user.PasswordHash,
					   user.IsEmailConfirmed,
					   user.ProfileImage,
					   user.CreatedAtUtc,
					   user.UpdatedAtUtc);
		}
	}
}
