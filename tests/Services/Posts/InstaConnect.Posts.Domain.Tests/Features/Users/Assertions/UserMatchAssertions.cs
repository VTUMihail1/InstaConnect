using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.Users.Assertions;

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

	extension(User user)
	{
		public void ShouldSatisfy(AddUserCommand request)
		{
			user.ShouldSatisfy(u => u.Matches(request));
		}

		public void ShouldSatisfy(UpdateUserCommand request)
		{
			user.ShouldSatisfy(u => u.Matches(request));
		}
	}
}
