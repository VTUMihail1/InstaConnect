using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(UserId response)
	{
		public bool Matches(
		User user,
		AddUserCommand request)
		{
			return response.Matches(user.Id);
		}

		public bool Matches(
		User user,
		UpdateUserCommand request)
		{
			return response.Matches(user.Id);
		}
	}

	extension(User user)
	{
		public bool Matches(AddUserCommand command)
		{
			return user.Id.Matches(command.Id) &&
				   user.FirstName == command.FirstName &&
				   user.LastName == command.LastName &&
				   user.Name.Matches(command.Name) &&
				   user.Email.Matches(command.Email) &&
				   user.ProfileImage.Matches(command.ProfileImage) &&
				   user.CreatedAtUtc == command.CreatedAtUtc &&
				   user.UpdatedAtUtc == command.UpdatedAtUtc;
		}

		public bool Matches(UpdateUserCommand command)
		{
			return user.Id.Matches(command.Id) &&
				   user.FirstName == command.FirstName &&
				   user.LastName == command.LastName &&
				   user.Name.Matches(command.Name) &&
				   user.Email.Matches(command.Email) &&
				   user.ProfileImage.Matches(command.ProfileImage) &&
				   user.UpdatedAtUtc == command.UpdatedAtUtc;
		}

		public bool Matches(DeleteUserCommand command)
		{
			return user.Id.Matches(command.Id);
		}
	}
}
