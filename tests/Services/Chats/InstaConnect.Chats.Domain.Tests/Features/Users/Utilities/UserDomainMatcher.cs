namespace InstaConnect.Chats.Domain.Tests.Features.Users.Utilities;

public static class UserDomainMatcher
{
	extension(AddUserCommand command)
	{
		public User IsUser()
		{
			return Matcher.Is<User>(u => u.Matches(command));
		}
	}

	extension(UpdateUserCommand command)
	{
		public User IsUser()
		{
			return Matcher.Is<User>(u => u.Matches(command));
		}
	}

	extension(DeleteUserCommand command)
	{
		public User IsUser()
		{
			return Matcher.Is<User>(u => u.Matches(command));
		}
	}
}
