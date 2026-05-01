namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimMockSetups
{
	extension(IUserClaimQueryService service)
	{
		public void SetupGetAllQuery(
		GetAllUserClaimsQueryRequest request,
		User user,
		ICollection<UserClaim> userClaims,
		CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(UserClaimMatcher.IsGetAllUserClaimsQuery(request), cancellationToken)
				.ReturnsResponse(userClaims.ToResponse(user, request));
		}
	}

	extension(IUserClaimCommandService service)
	{
		public void SetupAddCommand(
		AddUserClaimCommandRequest request,
		UserClaim userClaim,
		CancellationToken cancellationToken)
		{
			service
				.AddAsync(UserClaimMatcher.IsAddUserClaimCommand(request), cancellationToken)
				.ReturnsResponse(userClaim.ToResponse(request));
		}
	}
}
