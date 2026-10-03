using InstaConnect.Common.Application.Features.Requests.Abstractions;

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
				.SendAsync(request.IsGetAllUserClaimsQueryRequest(), cancellationToken)
				.ReturnsTaskResponse(userClaims.ToResponse(request, user));
		}

		public void SetupSendAsync(
			AddUserClaimApiRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsAddUserClaimCommandRequest(), cancellationToken)
				.ReturnsTaskResponse(userClaim.ToResponse(request));
		}
	}
}
