using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMockAssertions
{

	extension(IApplicationSender sender)
	{
		public async Task ShouldReceiveOneSendAsync(
			AddForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsAddForgotPasswordTokenCommandRequest(), cancellationToken);
		}
		public async Task ShouldReceiveOneSendAsync(
			VerifyForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsVerifyForgotPasswordTokenCommandRequest(), cancellationToken);
		}
	}
}
