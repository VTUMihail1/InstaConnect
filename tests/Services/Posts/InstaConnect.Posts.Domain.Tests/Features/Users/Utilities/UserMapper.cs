namespace InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		public User ToEntity(AddUserCommand command)
		{
			return new(command.Id,
					   command.FirstName,
					   command.LastName,
					   command.Email,
					   command.Name,
					   command.ProfileImage,
					   command.CreatedAtUtc,
					   command.UpdatedAtUtc);
		}
	}
}
