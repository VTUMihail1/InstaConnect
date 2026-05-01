using InstaConnect.Follows.Application.Features.Follows.Models;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

public static class FollowSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<Follow?> GetFollowByIdAsync(
		FollowIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetFollowByIdAsync(
				new FollowId(
							   new(id.FollowerId),
							   new(id.FollowingId)),
				cancellationToken);
		}
	}
}
