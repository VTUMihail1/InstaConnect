namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMockSetups
{
	extension(IForgotPasswordTokenCommandService service)
	{
		public void SetupAddAsync(
			AddForgotPasswordTokenCommandRequest request,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.AddAsync(ForgotPasswordTokenApplicationMatcher.IsAddForgotPasswordTokenCommand(request), cancellationToken)
				.ReturnsTaskResponse(forgotPasswordToken.ToResponse(request));
		}
	}
}
