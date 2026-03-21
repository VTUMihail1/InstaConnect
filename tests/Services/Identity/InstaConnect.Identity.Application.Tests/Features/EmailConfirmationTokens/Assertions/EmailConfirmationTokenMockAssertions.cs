using InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMockAssertions
{
    extension(IEmailConfirmationTokenCommandService emailConfirmationTokenService)
    {
        public async Task ShouldReceiveOneIssueAsync(
        AddEmailConfirmationTokenCommandRequest request,
        CancellationToken cancellationToken)
        {
            await emailConfirmationTokenService.ShouldHaveReceivedOne().AddAsync(EmailConfirmationTokenMatcher.IsAddEmailConfirmationTokenCommand(request), cancellationToken);
        }

        public async Task ShouldReceiveOneVerifyAsync(
            VerifyEmailConfirmationTokenCommandRequest request,
            CancellationToken cancellationToken)
        {
            await emailConfirmationTokenService.ShouldHaveReceivedOne().VerifyAsync(EmailConfirmationTokenMatcher.IsVerifyEmailConfirmationTokenCommand(request), cancellationToken);
        }
    }
}
