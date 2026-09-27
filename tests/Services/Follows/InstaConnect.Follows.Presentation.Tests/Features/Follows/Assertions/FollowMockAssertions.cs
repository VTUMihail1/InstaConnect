using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Assertions;

public static class FollowMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldReceiveOneSendAsync(
		GetAllFollowsApiRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetAllFollowsQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetAllFollowsForFollowingApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetAllFollowsForFollowingQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetFollowByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetFollowByIdQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			AddFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsAddFollowCommandRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			DeleteFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsDeleteFollowCommandRequest(), cancellationToken);
		}
	}
}
