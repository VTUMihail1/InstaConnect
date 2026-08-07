namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenMockSetups
{
	extension(IEmailConfirmationTokenCommandService service)
	{
		public void SetupAddAsync(
			AddEmailConfirmationTokenCommandRequest request,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.AddAsync(EmailConfirmationTokenApplicationMatcher.IsAddEmailConfirmationTokenCommand(request), cancellationToken)
				.ReturnsTaskResponse(emailConfirmationToken.ToResponse(request));
		}
	}
}
