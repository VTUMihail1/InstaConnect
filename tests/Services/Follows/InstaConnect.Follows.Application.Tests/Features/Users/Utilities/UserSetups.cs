using InstaConnect.Follows.Application.Features.Users.Models;
using InstaConnect.Follows.Application.Tests.Features.Users.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Application.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<User?> GetUserByIdAsync(
		UserIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserByIdAsync(
				new UserId(id.Id),
				cancellationToken);
		}
	}
}
