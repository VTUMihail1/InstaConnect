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
				.GetAllAsync(UserClaimApplicationMatcher.IsGetAllUserClaimsQuery(request), cancellationToken)
				.ReturnsTaskResponse(userClaims.ToResponse(request, user));
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
				.AddAsync(UserClaimApplicationMatcher.IsAddUserClaimCommand(request), cancellationToken)
				.ReturnsTaskResponse(userClaim.ToResponse(request));
		}
	}
}
