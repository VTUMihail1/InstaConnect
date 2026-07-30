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
				.AddAsync(ForgotPasswordTokenApplicationMatcher.IsAddForgotPasswordTokenCommand(request), cancellationToken)
				.ReturnsTaskResponse(forgotPasswordToken.ToResponse(request));
		}
	}
}
