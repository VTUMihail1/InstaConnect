namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimMockSetups
{
	extension(IUserClaimQueryService service)
	{
		public void SetupGetAllAsync(
		GetAllUserClaimsQueryRequest request,
		User user,
		ICollection<UserClaim> userClaims,
		CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.GetAllAsync(UserClaimApplicationMatcher.IsGetAllUserClaimsQuery(request), cancellationToken)
				.ReturnsTaskResponse(userClaims.ToResponse(request, user));
		}
	}

	extension(IUserClaimCommandService service)
	{
		public void SetupAddAsync(
		AddUserClaimCommandRequest request,
		UserClaim userClaim,
		CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.AddAsync(UserClaimApplicationMatcher.IsAddUserClaimCommand(request), cancellationToken)
				.ReturnsTaskResponse(userClaim.ToResponse(request));
		}
	}
}
