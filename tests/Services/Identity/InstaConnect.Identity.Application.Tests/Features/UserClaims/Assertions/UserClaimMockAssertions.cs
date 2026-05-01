using InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Assertions;

public static class UserClaimMockAssertions
{
	extension(IUserClaimQueryService userClaimService)
	{
		public async Task ShouldReceiveOneGetAllAsync(
		GetAllUserClaimsQueryRequest request,
		CancellationToken cancellationToken)
		{
			await userClaimService.ShouldHaveReceivedOne().GetAllAsync(UserClaimMatcher.IsGetAllUserClaimsQuery(request), cancellationToken);
		}
	}

	extension(IUserClaimCommandService userClaimService)
	{
		public async Task ShouldReceiveOneAddAsync(
		AddUserClaimCommandRequest request,
		CancellationToken cancellationToken)
		{
			await userClaimService.ShouldHaveReceivedOne().AddAsync(UserClaimMatcher.IsAddUserClaimCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeleteUserClaimCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userClaimService.ShouldHaveReceivedOne().DeleteAsync(UserClaimMatcher.IsDeleteUserClaimCommand(request), cancellationToken);
		}
	}
}
