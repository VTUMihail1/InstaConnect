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
			await emailConfirmationTokenService.ShouldHaveReceivedOne().AddAsync(EmailConfirmationTokenApplicationMatcher.IsAddEmailConfirmationTokenCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneVerifyAsync(
			VerifyEmailConfirmationTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await emailConfirmationTokenService.ShouldHaveReceivedOne().VerifyAsync(EmailConfirmationTokenApplicationMatcher.IsVerifyEmailConfirmationTokenCommand(request), cancellationToken);
		}
	}
}
