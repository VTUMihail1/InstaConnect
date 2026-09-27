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
				.AddAsync(request.IsAddForgotPasswordTokenCommand(), cancellationToken)
				.ReturnsTaskResponse(forgotPasswordToken.ToResponse(request));
		}
	}
}
