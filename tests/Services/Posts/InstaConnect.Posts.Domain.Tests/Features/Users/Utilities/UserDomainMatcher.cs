namespace InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

public static class UserDomainMatcher
{
	public static User IsUser(AddUserCommand command)
	{
		return Matcher.Is<User>(u => u.Matches(command));
	}

	public static User IsUser(UpdateUserCommand command)
	{
		return Matcher.Is<User>(u => u.Matches(command));
	}

	public static User IsUser(DeleteUserCommand command)
	{
		return Matcher.Is<User>(u => u.Matches(command));
	}
}
