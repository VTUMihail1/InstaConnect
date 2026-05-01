using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(AddUserCommandResponse response)
	{
		public void ShouldSatisfy(
		User user,
		AddUserCommandRequest request)
		{
			response.ShouldSatisfy(u => u.Matches(user, request));
		}
	}

	extension(UpdateUserCommandResponse response)
	{
		public void ShouldSatisfy(
		User user,
		UpdateUserCommandRequest request)
		{
			response.ShouldSatisfy(u => u.Matches(user, request));
		}
	}

	extension(User user)
	{
		public void ShouldSatisfy(AddUserCommandRequest request)
		{
			user.ShouldSatisfy(u => u.Matches(request));
		}

		public void ShouldSatisfy(UpdateUserCommandRequest request)
		{
			user.ShouldSatisfy(u => u.Matches(request));
		}
	}
}
