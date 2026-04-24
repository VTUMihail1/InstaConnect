using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimMockSetups
{
    extension(IApplicationSender sender)
    {
        public void SetupGetAllQueryRequest(
        GetAllUserClaimsApiRequest request,
        User user,
        ICollection<UserClaim> userClaims,
        CancellationToken cancellationToken)
        {
            sender
                .SendAsync(UserClaimMatcher.IsGetAllUserClaimsQueryRequest(request), cancellationToken)
                .ReturnsResponse(userClaims.ToResponse(user, request));
        }

        public void SetupAddCommandRequest(
            AddUserClaimApiRequest request,
            UserClaim userClaim,
            CancellationToken cancellationToken)
        {
            sender
                .SendAsync(UserClaimMatcher.IsAddUserClaimCommandRequest(request), cancellationToken)
                .ReturnsResponse(userClaim.ToResponse(request));
        }
    }
}
