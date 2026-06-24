using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

public static class FollowMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupGetAllQueryRequest(
		GetAllFollowsApiRequest request,
		User follower,
		ICollection<Follow> follows,
		CancellationToken cancellationToken)
		{
			sender
				.SendAsync(FollowMatcher.IsGetAllFollowsQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(follows.ToResponse(follower, request));
		}

		public void SetupGetAllForFollowingQueryRequest(
			GetAllFollowsForFollowingApiRequest request,
			User following,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(FollowMatcher.IsGetAllFollowsForFollowingQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(follows.ToResponse(following, request));
		}

		public void SetupGetByIdQueryRequest(
			GetFollowByIdApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(FollowMatcher.IsGetFollowByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(follow.ToResponse(request));
		}

		public void SetupAddCommandRequest(
			AddFollowApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(FollowMatcher.IsAddFollowCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(follow.ToResponse(request));
		}
	}
}
