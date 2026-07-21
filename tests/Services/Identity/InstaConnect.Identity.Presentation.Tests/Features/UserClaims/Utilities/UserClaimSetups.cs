using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<UserClaim?> GetClaimByIdAsync(
		UserClaimIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetClaimByIdAsync(
				new UserClaimId(new(id.Id), id.Claim),
				cancellationToken);
		}

		public async Task<UserClaim?> GetClaimByIdAsync(
		AddUserClaimApiResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetClaimByIdAsync(
				response.Response,
				cancellationToken);
		}
	}
}
