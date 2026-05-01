namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMockSetups
{
	extension(IForgotPasswordTokenCommandService service)
	{
		public void SetupAddCommand(
			AddForgotPasswordTokenCommandRequest request,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(ForgotPasswordTokenMatcher.IsAddForgotPasswordTokenCommand(request), cancellationToken)
				.ReturnsResponse(forgotPasswordToken.ToResponse(request));
		}
	}
}
