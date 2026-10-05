using InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMockAssertions
{
	extension(IForgotPasswordTokenCommandService forgotPasswordTokenService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
		AddForgotPasswordTokenCommandRequest request,
		CancellationToken cancellationToken)
		{
			await forgotPasswordTokenService.ShouldHaveReceivedOne().AddAsync(request.IsAddForgotPasswordTokenCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneVerifyAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await forgotPasswordTokenService.ShouldHaveReceivedOne().VerifyAsync(request.IsVerifyForgotPasswordTokenCommand(), cancellationToken);
		}
	}
}
