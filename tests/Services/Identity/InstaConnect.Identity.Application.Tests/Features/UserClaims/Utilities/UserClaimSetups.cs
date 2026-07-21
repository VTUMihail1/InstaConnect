using InstaConnect.Identity.Application.Features.UserClaims.Models;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<UserClaim?> GetUserClaimByIdAsync(
		UserClaimIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetClaimByIdAsync(
				new UserClaimId(new(id.Id), id.Claim),
				cancellationToken);
		}

		public async Task<UserClaim?> GetUserClaimByIdAsync(
		AddUserClaimCommandResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserClaimByIdAsync(
				response.Response,
				cancellationToken);
		}
	}
}
