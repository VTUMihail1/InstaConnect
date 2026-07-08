using InstaConnect.Chats.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(UserId response)
	{
		public void ShouldSatisfy(
			User user,
			AddUserCommand request)
		{
			response.ShouldSatisfy(u => u.Matches(user, request));
		}

		public void ShouldSatisfy(
			User user,
			UpdateUserCommand request)
		{
			response.ShouldSatisfy(u => u.Matches(user, request));
		}
	}

	extension(User u)
	{
		public void ShouldSatisfy(AddUserCommand request)
		{
			u.ShouldSatisfy(u => u.Matches(request));
		}

		public void ShouldSatisfy(UpdateUserCommand request)
		{
			u.ShouldSatisfy(u => u.Matches(request));
		}
	}
}
