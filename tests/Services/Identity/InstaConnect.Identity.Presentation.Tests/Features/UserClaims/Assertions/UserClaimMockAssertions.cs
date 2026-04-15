using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Assertions;

public static class UserClaimMockAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldReceiveOneSendAsync(
        GetAllUserClaimsApiRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(UserClaimMatcher.IsGetAllUserClaimsQueryRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            AddUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(UserClaimMatcher.IsAddUserClaimCommandRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            DeleteUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(UserClaimMatcher.IsDeleteUserClaimCommandRequest(request), cancellationToken);
        }
    }
}
