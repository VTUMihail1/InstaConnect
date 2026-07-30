using InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Assertions;

public static class FollowMockAssertions
{
	extension(IFollowQueryService followService)
	{
		public async Task ShouldReceiveOneGetAllAsync(
		GetAllFollowsQueryRequest request,
		CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOne().GetAllAsync(FollowApplicationMatcher.IsGetAllFollowsQuery(request), cancellationToken);
		}

		public async Task ShouldReceiveOneGetAllForFollowingAsync(
			GetAllFollowsForFollowingQueryRequest request,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOne().GetAllForFollowingAsync(FollowApplicationMatcher.IsGetAllFollowsForFollowingQuery(request), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			GetFollowByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOne().GetByIdAsync(FollowApplicationMatcher.IsGetFollowByIdQuery(request), cancellationToken);
		}
	}

	extension(IFollowCommandService followService)
	{
		public async Task ShouldReceiveOneAddAsync(
		AddFollowCommandRequest request,
		CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOne().AddAsync(FollowApplicationMatcher.IsAddFollowCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeleteFollowCommandRequest request,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOne().DeleteAsync(FollowApplicationMatcher.IsDeleteFollowCommand(request), cancellationToken);
		}
	}
}
