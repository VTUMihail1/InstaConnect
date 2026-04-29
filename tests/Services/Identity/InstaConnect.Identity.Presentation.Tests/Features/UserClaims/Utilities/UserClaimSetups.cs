using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<UserClaim?> GetUserClaimByIdAsync(
		UserClaimIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserClaimByIdAsync(
				new UserClaimId(new(id.Id), id.Claim),
				cancellationToken);
		}
	}
}
