namespace InstaConnect.Chats.Application.Tests.Features.Users.Utilities;

public static class UserMatcher
{
	public static AddUserCommand IsAddUserCommand(AddUserCommandRequest request)
	{
		return Matcher.Is<AddUserCommand>(u => u.Matches(request));
	}

	public static UpdateUserCommand IsUpdateUserCommand(UpdateUserCommandRequest request)
	{
		return Matcher.Is<UpdateUserCommand>(u => u.Matches(request));
	}

	public static DeleteUserCommand IsDeleteUserCommand(DeleteUserCommandRequest request)
	{
		return Matcher.Is<DeleteUserCommand>(u => u.Matches(request));
	}
}
