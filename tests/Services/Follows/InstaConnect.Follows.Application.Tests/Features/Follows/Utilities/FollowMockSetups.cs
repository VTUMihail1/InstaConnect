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
				.GetAllAsync(request.IsGetAllFollowsQuery(), cancellationToken)
				.ReturnsTaskResponse(follows.ToResponse(request, follower));
		}

		public void SetupGetAllForFollowingAsync(
			GetAllFollowsForFollowingQueryRequest request,
			User following,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			likeService
				.GetAllForFollowingAsync(request.IsGetAllFollowsForFollowingQuery(), cancellationToken)
				.ReturnsTaskResponse(follows.ToResponse(request, following));
		}

		public void SetupGetByIdAsync(
			GetFollowByIdQueryRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			likeService
				.GetByIdAsync(request.IsGetFollowByIdQuery(), cancellationToken)
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
				.AddAsync(request.IsAddFollowCommand(), cancellationToken)
				.ReturnsTaskResponse(follow.ToResponse(request));
		}
	}
}
