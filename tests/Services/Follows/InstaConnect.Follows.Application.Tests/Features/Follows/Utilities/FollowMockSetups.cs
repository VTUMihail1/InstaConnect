namespace InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

public static class FollowMockSetups
{
	extension(IFollowQueryService likeService)
	{
		public void SetupGetAllQuery(
		GetAllFollowsQueryRequest request,
		User follower,
		ICollection<Follow> follows,
		CancellationToken cancellationToken)
		{
			likeService
				.GetAllAsync(FollowMatcher.IsGetAllFollowsQuery(request), cancellationToken)
				.ReturnsResponse(follows.ToResponse(follower, request));
		}

		public void SetupGetAllForFollowingQuery(
			GetAllFollowsForFollowingQueryRequest request,
			User following,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			likeService
				.GetAllForFollowingAsync(FollowMatcher.IsGetAllFollowsForFollowingQuery(request), cancellationToken)
				.ReturnsResponse(follows.ToResponse(following, request));
		}

		public void SetupGetByIdQuery(
			GetFollowByIdQueryRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			likeService
				.GetByIdAsync(FollowMatcher.IsGetFollowByIdQuery(request), cancellationToken)
				.ReturnsResponse(follow.ToResponse(request));
		}
	}

	extension(IFollowCommandService likeService)
	{
		public void SetupAddCommand(
		AddFollowCommandRequest request,
		Follow follow,
		CancellationToken cancellationToken)
		{
			likeService
				.AddAsync(FollowMatcher.IsAddFollowCommand(request), cancellationToken)
				.ReturnsResponse(follow.ToResponse(request));
		}
	}
}
