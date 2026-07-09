using InstaConnect.Follows.Events.Features.Follows;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

public static class FollowMatcher
{
	public static FollowInclude IsFollowInclude(DeleteFollowCommand command, FollowInclude include)
	{
		return Matcher.Is<FollowInclude>(p => p.Matches(include));
	}

	public static Follow IsFollow(AddFollowCommand command)
	{
		return Matcher.Is<Follow>(p => p.Matches(command));
	}

	public static Follow IsFollow(DeleteFollowCommand command)
	{
		return Matcher.Is<Follow>(p => p.Matches(command));
	}

	public static FollowAddedEventRequest IsFollowAddedEventRequest(Follow follow)
	{
		return Matcher.Is<FollowAddedEventRequest>(p => p.Matches(follow));
	}

	public static FollowDeletedEventRequest IsFollowDeletedEventRequest(Follow follow)
	{
		return Matcher.Is<FollowDeletedEventRequest>(p => p.Matches(follow));
	}

	public static FollowAddedNotificationRequest IsFollowAddedNotificationRequest(Follow follow)
	{
		return Matcher.Is<FollowAddedNotificationRequest>(p => p.Matches(follow));
	}
}
