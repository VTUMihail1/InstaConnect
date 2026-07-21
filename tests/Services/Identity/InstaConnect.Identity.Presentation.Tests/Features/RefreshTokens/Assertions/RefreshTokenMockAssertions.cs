using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMockAssertions
{

	extension(IApplicationSender sender)
	{
		public async Task ShouldReceiveOneSendAsync(
			IssueRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(RefreshTokenMatcher.IsIssueRefreshTokenCommandRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			RotateRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(RefreshTokenMatcher.IsRotateRefreshTokenCommandRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			DeleteCurrentRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(RefreshTokenMatcher.IsDeleteCurrentRefreshTokenCommandRequest(request), cancellationToken);
		}
	}

	extension(IRefreshTokenCookieStore store)
	{
		public void ShouldReceiveOneSet(
			IssueRefreshTokenApiRequest request,
			RefreshToken refreshToken)
		{
			store.ShouldHaveReceivedOne().Set(RefreshTokenMatcher.IsRefreshTokenCookieRequest(request, refreshToken));
		}

		public void ShouldReceiveOneSet(
			RotateRefreshTokenApiRequest request,
			RefreshToken refreshToken)
		{
			store.ShouldHaveReceivedOne().Set(RefreshTokenMatcher.IsRefreshTokenCookieRequest(request, refreshToken));
		}

		public void ShouldReceiveOneDelete(DeleteCurrentRefreshTokenApiRequest request)
		{
			store.ShouldHaveReceivedOne().Delete();
		}
	}
}
