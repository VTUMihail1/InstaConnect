using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMockAssertions
{

	extension(IApplicationSender sender)
	{
		public async Task ShouldHaveReceivedOneSendAsync(
			IssueRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsIssueRefreshTokenCommandRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			RotateRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsRotateRefreshTokenCommandRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			DeleteCurrentRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsDeleteCurrentRefreshTokenCommandRequest(), cancellationToken);
		}
	}

	extension(IRefreshTokenCookieStore store)
	{
		public void ShouldHaveReceivedOneSet(
			IssueRefreshTokenApiRequest request,
			RefreshToken refreshToken)
		{
			store.ShouldHaveReceivedOne().Set(request.IsRefreshTokenCookieRequest(refreshToken));
		}

		public void ShouldHaveReceivedOneSet(
			RotateRefreshTokenApiRequest request,
			RefreshToken refreshToken)
		{
			store.ShouldHaveReceivedOne().Set(request.IsRefreshTokenCookieRequest(refreshToken));
		}

		public void ShouldHaveReceivedOneDelete(DeleteCurrentRefreshTokenApiRequest request)
		{
			store.ShouldHaveReceivedOne().Delete();
		}
	}
}
