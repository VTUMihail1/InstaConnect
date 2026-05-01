using InstaConnect.Chats.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(User user)
	{
		public void ShouldSatisfy(UserAddedEventRequest request)
		{
			user.ShouldSatisfy(u => u.Matches(request));
		}

		public void ShouldSatisfy(UserUpdatedEventRequest request)
		{
			user.ShouldSatisfy(u => u.Matches(request));
		}
	}

	extension(User u)
	{
		public void ShouldSatisfy(User user)
		{
			user.ShouldSatisfy(u => u.Matches(user));
		}
	}
}
