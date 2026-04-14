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
            await followService.ShouldHaveReceivedOne().GetAllAsync(FollowMatcher.IsGetAllFollowsQuery(request), cancellationToken);
        }

        public async Task ShouldReceiveOneGetAllForFollowingAsync(
            GetAllFollowsForFollowingQueryRequest request,
            CancellationToken cancellationToken)
        {
            await followService.ShouldHaveReceivedOne().GetAllForFollowingAsync(FollowMatcher.IsGetAllFollowsForFollowingQuery(request), cancellationToken);
        }

        public async Task ShouldReceiveOneGetByIdAsync(
            GetFollowByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await followService.ShouldHaveReceivedOne().GetByIdAsync(FollowMatcher.IsGetFollowByIdQuery(request), cancellationToken);
        }
    }

    extension(IFollowCommandService followService)
    {
        public async Task ShouldReceiveOneAddAsync(
        AddFollowCommandRequest request,
        CancellationToken cancellationToken)
        {
            await followService.ShouldHaveReceivedOne().AddAsync(FollowMatcher.IsAddFollowCommand(request), cancellationToken);
        }

        public async Task ShouldReceiveOneDeleteAsync(
            DeleteFollowCommandRequest request,
            CancellationToken cancellationToken)
        {
            await followService.ShouldHaveReceivedOne().DeleteAsync(FollowMatcher.IsDeleteFollowCommand(request), cancellationToken);
        }
    }
}
