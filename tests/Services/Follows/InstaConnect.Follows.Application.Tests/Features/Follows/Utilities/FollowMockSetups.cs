namespace InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

public static class FollowMockSetups
{
	extension(IFollowQueryService likeService)
	{
		public void SetupGetAllAsync(
		GetAllFollowsQueryRequest request,
		User follower,
		ICollection<Follow> follows,
		CancellationToken cancellationToken)
		{
			likeService
				.ClearCalls()
				.GetAllAsync(FollowApplicationMatcher.IsGetAllFollowsQuery(request), cancellationToken)
				.ReturnsTaskResponse(follows.ToResponse(request, follower));
		}

		public void SetupGetAllForFollowingAsync(
			GetAllFollowsForFollowingQueryRequest request,
			User following,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			likeService
				.ClearCalls()
				.GetAllForFollowingAsync(FollowApplicationMatcher.IsGetAllFollowsForFollowingQuery(request), cancellationToken)
				.ReturnsTaskResponse(follows.ToResponse(request, following));
		}

		public void SetupGetByIdAsync(
			GetFollowByIdQueryRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			likeService
				.ClearCalls()
				.GetByIdAsync(FollowApplicationMatcher.IsGetFollowByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(follow.ToResponse(request));
		}
	}

	extension(IFollowCommandService likeService)
	{
		public void SetupAddAsync(
		AddFollowCommandRequest request,
		Follow follow,
		CancellationToken cancellationToken)
		{
			likeService
				.ClearCalls()
				.AddAsync(FollowApplicationMatcher.IsAddFollowCommand(request), cancellationToken)
				.ReturnsTaskResponse(follow.ToResponse(request));
		}
	}
}
