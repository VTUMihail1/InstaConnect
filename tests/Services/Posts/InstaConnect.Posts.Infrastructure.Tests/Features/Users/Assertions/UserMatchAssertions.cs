using InstaConnect.Posts.Infrastructure.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Users.Assertions;

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

	extension(UserAddedEventRequest r)
	{
		public void ShouldSatisfy(UserAddedEventRequest request)
		{
			r.ShouldSatisfy(r => r.Matches(request));
		}
	}

	extension(UserUpdatedEventRequest r)
	{
		public void ShouldSatisfy(UserUpdatedEventRequest request)
		{
			r.ShouldSatisfy(r => r.Matches(request));
		}

	}

	extension(UserDeletedEventRequest r)
	{
		public void ShouldSatisfy(UserDeletedEventRequest request)
		{
			r.ShouldSatisfy(r => r.Matches(request));
		}
	}
}
