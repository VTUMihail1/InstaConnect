using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMockAssertions
{

	extension(IApplicationSender sender)
	{
		public async Task ShouldHaveReceivedOneSendAsync(
			AddForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsAddForgotPasswordTokenCommandRequest(), cancellationToken);
		}
		public async Task ShouldHaveReceivedOneSendAsync(
			VerifyForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsVerifyForgotPasswordTokenCommandRequest(), cancellationToken);
		}
	}
}
