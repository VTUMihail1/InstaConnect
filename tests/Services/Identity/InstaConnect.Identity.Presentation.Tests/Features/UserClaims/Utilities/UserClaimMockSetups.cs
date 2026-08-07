using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllUserClaimsApiRequest request,
		User user,
		ICollection<UserClaim> userClaims,
		CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(UserClaimPresentationMatcher.IsGetAllUserClaimsQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(userClaims.ToResponse(request, user));
		}

		public void SetupSendAsync(
			AddUserClaimApiRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			sender
				.ClearCalls()
				.SendAsync(UserClaimPresentationMatcher.IsAddUserClaimCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(userClaim.ToResponse(request));
		}
	}
}
