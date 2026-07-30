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
				.SendAsync(UserClaimPresentationMatcher.IsGetAllUserClaimsQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(userClaims.ToResponse(request, user));
		}

		public void SetupAddCommandRequest(
			AddUserClaimApiRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserClaimPresentationMatcher.IsAddUserClaimCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(userClaim.ToResponse(request));
		}
	}
}
