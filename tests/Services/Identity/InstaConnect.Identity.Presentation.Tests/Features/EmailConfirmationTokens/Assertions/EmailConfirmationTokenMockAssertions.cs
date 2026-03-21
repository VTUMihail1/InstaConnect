using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMockAssertions
{

    extension(IApplicationSender sender)
    {
        public async Task ShouldReceiveOneSendAsync(
            AddEmailConfirmationTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(EmailConfirmationTokenMatcher.IsAddEmailConfirmationTokenCommandRequest(request), cancellationToken);
        }
        public async Task ShouldReceiveOneSendAsync(
            VerifyEmailConfirmationTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(EmailConfirmationTokenMatcher.IsVerifyEmailConfirmationTokenCommandRequest(request), cancellationToken);
        }
    }
}
