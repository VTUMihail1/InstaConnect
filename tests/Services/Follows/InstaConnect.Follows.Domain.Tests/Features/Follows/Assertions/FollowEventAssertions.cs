using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Events.Features.Follows;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;

public static class FollowEventAssertions
{
	extension(FollowAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddFollowCommand command, Follow entity)
		{
			return r.Matches(command, entity);
		}
	}

	extension(FollowDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeleteFollowCommand command, Follow entity)
		{
			return r.Matches(command, entity);
		}
	}
}
