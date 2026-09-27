using InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMockAssertions
{
	extension(IEmailConfirmationTokenCommandService emailConfirmationTokenService)
	{
		public async Task ShouldReceiveOneAddAsync(
		AddEmailConfirmationTokenCommandRequest request,
		CancellationToken cancellationToken)
		{
			await emailConfirmationTokenService.ShouldHaveReceivedOne().AddAsync(request.IsAddEmailConfirmationTokenCommand(), cancellationToken);
		}

		public async Task ShouldReceiveOneVerifyAsync(
			VerifyEmailConfirmationTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await emailConfirmationTokenService.ShouldHaveReceivedOne().VerifyAsync(request.IsVerifyEmailConfirmationTokenCommand(), cancellationToken);
		}
	}
}
