using InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMockAssertions
{
	extension(IForgotPasswordTokenCommandService forgotPasswordTokenService)
	{
		public async Task ShouldReceiveOneAddAsync(
		AddForgotPasswordTokenCommandRequest request,
		CancellationToken cancellationToken)
		{
			await forgotPasswordTokenService.ShouldHaveReceivedOne().AddAsync(ForgotPasswordTokenApplicationMatcher.IsAddForgotPasswordTokenCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneVerifyAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await forgotPasswordTokenService.ShouldHaveReceivedOne().VerifyAsync(ForgotPasswordTokenApplicationMatcher.IsVerifyForgotPasswordTokenCommand(request), cancellationToken);
		}
	}
}
