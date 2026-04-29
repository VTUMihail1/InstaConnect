namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenMockSetups
{
	extension(IEmailConfirmationTokenCommandService service)
	{
		public void SetupAddCommand(
			AddEmailConfirmationTokenCommandRequest request,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(EmailConfirmationTokenMatcher.IsAddEmailConfirmationTokenCommand(request), cancellationToken)
				.ReturnsResponse(emailConfirmationToken.ToResponse(request));
		}
	}
}
