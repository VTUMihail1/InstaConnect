namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		public User ToFull()
		{
			return new(user.Id,
					   user.FirstName,
					   user.LastName,
					   user.Email,
					   user.Name,
					   user.ProfileImage,
					   user.CreatedAtUtc,
					   user.UpdatedAtUtc);
		}
	}
}
