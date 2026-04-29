using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IFollowCommandRepository GetFollowCommandRepository()
		{
			return serviceProvider.GetRequiredService<IFollowCommandRepository>();
		}

		public IFollowIncludeBuilderFactory GetFollowIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IFollowIncludeBuilderFactory>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IFollowCommandRepository GetFollowCommandRepository()
		{
			return serviceScope.ServiceProvider.GetFollowCommandRepository();
		}

		public IFollowIncludeBuilderFactory GetFollowIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetFollowIncludeBuilderFactory();
		}

		public async Task<Follow?> GetFollowByIdAsync(
			FollowId id,
			CancellationToken cancellationToken)
		{
			var Include = serviceScope.GetFollowIncludeBuilderFactory().Create().WithFollower().WithFollowing().Build();

			return await serviceScope.GetFollowCommandRepository().GetByIdAsync(id, Include, cancellationToken);
		}

		public async Task AddFollowAsync(
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetFollowCommandRepository().AddAsync(follow, cancellationToken);
		}

		public async Task AddFollowRangeAsync(
			IEnumerable<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetFollowCommandRepository().AddRangeAsync(follows, cancellationToken);
		}

		public async Task DeleteFollowAsync(
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetFollowCommandRepository().DeleteAsync(follow, cancellationToken);
		}
	}
}
