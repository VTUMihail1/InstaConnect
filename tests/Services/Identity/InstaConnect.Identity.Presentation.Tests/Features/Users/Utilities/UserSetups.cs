using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<User?> GetUserByIdAsync(
		UserIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new UserId(id.Id),
				cancellationToken);
		}

		public async Task<User?> GetUserByIdAsync(
		AddUserApiResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<User?> GetUserByIdAsync(
		UpdateCurrentUserApiResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<GetCurrentUserByIdApiResponse> GetResponseFromCache(
		GetCurrentUserByIdApiRequest request,
		CancellationToken cancellationToken)
		{
			return (await serviceScope.GetCacheHandler().GetAsync<GetCurrentUserByIdApiResponse>(new GetCurrentUserByIdQueryRequest(request.CurrentId).Key, cancellationToken))!;
		}

		public async Task<GetCurrentUserDetailsByIdApiResponse?> GetResponseFromCache(
		GetCurrentUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
		{
			return (await serviceScope.GetCacheHandler().GetAsync<GetCurrentUserDetailsByIdApiResponse>(new GetCurrentUserDetailsByIdQueryRequest(request.CurrentId).Key, cancellationToken))!;
		}
	}
}
