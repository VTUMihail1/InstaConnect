using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMockAssertions
{

    extension(IApplicationSender sender)
    {
        public async Task ShouldReceiveOneSendAsync(
            AddForgotPasswordTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(ForgotPasswordTokenMatcher.IsAddForgotPasswordTokenCommandRequest(request), cancellationToken);
        }
        public async Task ShouldReceiveOneSendAsync(
            VerifyForgotPasswordTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(ForgotPasswordTokenMatcher.IsVerifyForgotPasswordTokenCommandRequest(request), cancellationToken);
        }
    }
}
