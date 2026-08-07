using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

public static class FollowMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllFollowsApiRequest request,
		User follower,
		ICollection<Follow> follows,
		CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(FollowPresentationMatcher.IsGetAllFollowsQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(follows.ToResponse(request, follower));
		}

		public void SetupSendAsync(
			GetAllFollowsForFollowingApiRequest request,
			User following,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(FollowPresentationMatcher.IsGetAllFollowsForFollowingQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(follows.ToResponse(request, following));
		}

		public void SetupSendAsync(
			GetFollowByIdApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(FollowPresentationMatcher.IsGetFollowByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(follow.ToResponse(request));
		}

		public void SetupSendAsync(
			AddFollowApiRequest request,
			Follow follow,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(FollowPresentationMatcher.IsAddFollowCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(follow.ToResponse(request));
		}
	}
}
