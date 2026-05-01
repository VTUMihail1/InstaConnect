using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

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

		public async Task<GetCurrentUserByIdQueryResponse> GetResponseFromCache(
		GetCurrentUserByIdQueryRequest request,
		CancellationToken cancellationToken)
		{
			return (await serviceScope.GetCacheHandler().GetAsync<GetCurrentUserByIdQueryResponse>(request.Key, cancellationToken))!;
		}

		public async Task<GetCurrentUserDetailsByIdQueryResponse?> GetResponseFromCache(
		GetCurrentUserDetailsByIdQueryRequest request,
		CancellationToken cancellationToken)
		{
			return (await serviceScope.GetCacheHandler().GetAsync<GetCurrentUserDetailsByIdQueryResponse>(request.Key, cancellationToken))!;
		}
	}
}
