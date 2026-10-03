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
				.AddAsync(request.IsAddEmailConfirmationTokenCommand(), cancellationToken)
				.ReturnsTaskResponse(emailConfirmationToken.ToResponse(request));
		}
	}
}
