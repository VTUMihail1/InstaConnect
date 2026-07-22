using InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Events.Features.Follows;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Assertions;

public static class FollowEventAssertions
{
	extension(FollowAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddFollowCommandRequest request, Follow entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(FollowDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeleteFollowCommandRequest request, Follow entity)
		{
			return r.Matches(request, entity);
		}
	}
}
