using InstaConnect.Follows.Events.Features.Follows;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

public static class FollowDomainMatcher
{
	extension(DeleteFollowCommand command)
	{
		public FollowInclude IsFollowInclude(FollowInclude include)
		{
			return Matcher.Is<FollowInclude>(p => p.Matches(command, include));
		}

		public Follow IsFollow()
		{
			return Matcher.Is<Follow>(p => p.Matches(command));
		}

		public FollowDeletedEventRequest IsFollowDeletedEventRequest(Follow follow)
		{
			return Matcher.Is<FollowDeletedEventRequest>(p => p.Matches(command, follow));
		}
	}

	extension(AddFollowCommand command)
	{
		public Follow IsFollow()
		{
			return Matcher.Is<Follow>(p => p.Matches(command));
		}

		public FollowAddedEventRequest IsFollowAddedEventRequest(Follow follow)
		{
			return Matcher.Is<FollowAddedEventRequest>(p => p.Matches(command, follow));
		}

		public FollowAddedNotificationRequest IsFollowAddedNotificationRequest(Follow follow)
		{
			return Matcher.Is<FollowAddedNotificationRequest>(p => p.Matches(command, follow));
		}
	}
}
