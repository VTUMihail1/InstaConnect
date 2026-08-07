namespace InstaConnect.Chats.Infrastructure.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(User user)
	{
		public bool Matches(UserAddedEventRequest request)
		{
			return user.Matches(request.User);
		}

		public bool Matches(UserUpdatedEventRequest request)
		{
			return user.Matches(request.User);
		}
	}

	extension(UserAddedEventRequest r)
	{
		public bool Matches(UserAddedEventRequest request)
		{
			return r.User.Matches(request.User);
		}
	}

	extension(UserUpdatedEventRequest r)
	{
		public bool Matches(UserUpdatedEventRequest request)
		{
			return r.User.Matches(request.User);
		}
	}

	extension(UserDeletedEventRequest r)
	{
		public bool Matches(UserDeletedEventRequest request)
		{
			return r.User.Matches(request.User);
		}
	}

	extension(AddUserCommandRequest command)
	{
		public bool Matches(UserAddedEventRequest request)
		{
			return command.Id == request.User.Id &&
				   command.Email == request.User.Email &&
				   command.Name == request.User.Name &&
				   command.FirstName == request.User.FirstName &&
				   command.LastName == request.User.LastName &&
				   command.ProfileImageUrl == request.User.ProfileImageUrl;
		}
	}

	extension(UpdateUserCommandRequest command)
	{
		public bool Matches(UserUpdatedEventRequest request)
		{
			return command.Id == request.User.Id &&
				   command.Email == request.User.Email &&
				   command.Name == request.User.Name &&
				   command.FirstName == request.User.FirstName &&
				   command.LastName == request.User.LastName &&
				   command.ProfileImageUrl == request.User.ProfileImageUrl;
		}
	}

	extension(DeleteUserCommandRequest command)
	{
		public bool Matches(UserDeletedEventRequest request)
		{
			return command.Id == request.User.Id;
		}
	}
}
