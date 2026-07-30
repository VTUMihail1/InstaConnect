using InstaConnect.Follows.Events.Features.Follows;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

public static class FollowDomainMatcher
{
	public static FollowInclude IsFollowInclude(DeleteFollowCommand command, FollowInclude include)
	{
		return Matcher.Is<FollowInclude>(p => p.Matches(command, include));
	}

	public static Follow IsFollow(AddFollowCommand command)
	{
		return Matcher.Is<Follow>(p => p.Matches(command));
	}

	public static Follow IsFollow(DeleteFollowCommand command)
	{
		return Matcher.Is<Follow>(p => p.Matches(command));
	}

	public static FollowAddedEventRequest IsFollowAddedEventRequest(AddFollowCommand command, Follow follow)
	{
		return Matcher.Is<FollowAddedEventRequest>(p => p.Matches(command, follow));
	}

	public static FollowDeletedEventRequest IsFollowDeletedEventRequest(DeleteFollowCommand command, Follow follow)
	{
		return Matcher.Is<FollowDeletedEventRequest>(p => p.Matches(command, follow));
	}

	public static FollowAddedNotificationRequest IsFollowAddedNotificationRequest(AddFollowCommand command, Follow follow)
	{
		return Matcher.Is<FollowAddedNotificationRequest>(p => p.Matches(command, follow));
	}
}
