using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;

public static class FollowMatchAssertions
{
	extension(FollowId response)
	{
		public void ShouldSatisfy(Follow follow, AddFollowCommand command)
		{
			response.ShouldSatisfy(p => p.Matches(follow, command));
		}
	}

	extension(FollowResponse response)
	{
		public void ShouldSatisfy(Follow follow, GetFollowByIdQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(follow, query));
		}
	}

	extension(FollowCollectionResponse response)
	{
		public void ShouldSatisfy(
		User follower,
		ICollection<Follow> follows,
		GetAllFollowsQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(follower, follows, query));
		}

		public void ShouldSatisfy(
			User follower,
			ICollection<Follow> follows,
			GetAllFollowsQuery query,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(follower, follows, query, termTransformer));
		}

		public void ShouldSatisfy(
		User following,
		ICollection<Follow> follows,
		GetAllFollowsForFollowingQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(following, follows, query));
		}

		public void ShouldSatisfy(
			User following,
			ICollection<Follow> follows,
			GetAllFollowsForFollowingQuery query,
			ISortEnumTermTransformer<Follow> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(following, follows, query, termTransformer));
		}
	}

	extension(Follow follow)
	{
		public void ShouldSatisfy(AddFollowCommand command)
		{
			follow.ShouldSatisfy(p => p.Matches(command));
		}
	}
}
