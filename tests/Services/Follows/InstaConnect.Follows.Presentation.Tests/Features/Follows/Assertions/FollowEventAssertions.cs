using InstaConnect.Follows.Events.Features.Follows;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Assertions;

public static class FollowEventAssertions
{
	extension(FollowAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddFollowApiRequest request, Follow entity)
		{
			return r.Matches(request, entity);
		}
	}

	extension(FollowDeletedEventRequest r)
	{
		public bool ShouldSatisfy(DeleteFollowApiRequest request, Follow entity)
		{
			return r.Matches(request, entity);
		}
	}
}
