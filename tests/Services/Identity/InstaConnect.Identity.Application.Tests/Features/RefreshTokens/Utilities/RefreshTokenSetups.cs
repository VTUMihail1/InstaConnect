using InstaConnect.Identity.Application.Features.RefreshTokens.Models;
using InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<RefreshToken?> GetRefreshTokenByIdAsync(
		RefreshTokenIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetRefreshTokenByIdAsync(
				new RefreshTokenId(new(id.Id), id.Value),
				cancellationToken);
		}
	}
}
