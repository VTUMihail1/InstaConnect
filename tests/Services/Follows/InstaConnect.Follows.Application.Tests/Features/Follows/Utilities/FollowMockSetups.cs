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
				.GetAllAsync(FollowApplicationMatcher.IsGetAllFollowsQuery(request), cancellationToken)
				.ReturnsTaskResponse(follows.ToResponse(request, follower));
		}

		public void SetupGetAllForFollowingQuery(
			GetAllFollowsForFollowingQueryRequest request,
			User following,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			likeService
				.GetAllForFollowingAsync(FollowApplicationMatcher.IsGetAllFollowsForFollowingQuery(request), cancellationToken)
				.ReturnsTaskResponse(follows.ToResponse(request, following));
		}

		public void SetupGetByIdQuery(
			GetFollowByIdQueryRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			likeService
				.GetByIdAsync(FollowApplicationMatcher.IsGetFollowByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(follow.ToResponse(request));
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
				.AddAsync(FollowApplicationMatcher.IsAddFollowCommand(request), cancellationToken)
				.ReturnsTaskResponse(follow.ToResponse(request));
		}
	}
}
