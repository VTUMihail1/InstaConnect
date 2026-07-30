namespace InstaConnect.Chats.Infrastructure.Tests.Features.Users.Utilities;

public static class UserInfrastructureMatcher
{
	public static AddUserCommandRequest IsAddUserCommandRequest(UserAddedEventRequest request)
	{
		return Matcher.Is<AddUserCommandRequest>(u => u.Matches(request));
	}

	public static UpdateUserCommandRequest IsUpdateUserCommandRequest(UserUpdatedEventRequest request)
	{
		return Matcher.Is<UpdateUserCommandRequest>(u => u.Matches(request));
	}

	public static DeleteUserCommandRequest IsDeleteUserCommandRequest(UserDeletedEventRequest request)
	{
		return Matcher.Is<DeleteUserCommandRequest>(u => u.Matches(request));
	}
}
