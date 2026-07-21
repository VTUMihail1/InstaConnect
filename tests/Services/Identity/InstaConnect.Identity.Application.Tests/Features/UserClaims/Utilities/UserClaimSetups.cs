using InstaConnect.Identity.Application.Features.UserClaims.Models;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<UserClaim?> GetClaimByIdAsync(
		UserClaimIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetClaimByIdAsync(
				new UserClaimId(new(id.Id), id.Claim),
				cancellationToken);
		}

		public async Task<UserClaim?> GetClaimByIdAsync(
		AddUserClaimCommandResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetClaimByIdAsync(
				response.Response,
				cancellationToken);
		}
	}
}
