using InstaConnect.Common.Presentation.Tests.Features.Extensions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public UserClaimController GetUserClaimController()
		{
			return serviceProvider.GetRequiredService<UserClaimController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public UserClaimController GetUserClaimController()
		{
			return serviceScope.ServiceProvider.GetUserClaimController();
		}

		internal async Task<UserClaim?> GetByIdAsync(
		UserClaimIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new UserClaimId(new(id.Id), id.Claim),
				cancellationToken);
		}

		public async Task<UserClaim?> GetByIdAsync(
		AddUserClaimApiResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<UserClaim?> GetByIdAsync(
		ActionResult<AddUserClaimApiResponse> result,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				result.GetValue(),
				cancellationToken);
		}
	}
}
