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
			await followService.ShouldHaveReceivedOne().GetAllAsync(request.IsGetAllFollowsQuery(), cancellationToken);
		}

		public async Task ShouldReceiveOneGetAllForFollowingAsync(
			GetAllFollowsForFollowingQueryRequest request,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOne().GetAllForFollowingAsync(request.IsGetAllFollowsForFollowingQuery(), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			GetFollowByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOne().GetByIdAsync(request.IsGetFollowByIdQuery(), cancellationToken);
		}
	}

	extension(IFollowCommandService followService)
	{
		public async Task ShouldReceiveOneAddAsync(
		AddFollowCommandRequest request,
		CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOne().AddAsync(request.IsAddFollowCommand(), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeleteFollowCommandRequest request,
			CancellationToken cancellationToken)
		{
			await followService.ShouldHaveReceivedOne().DeleteAsync(request.IsDeleteFollowCommand(), cancellationToken);
		}
	}
}
