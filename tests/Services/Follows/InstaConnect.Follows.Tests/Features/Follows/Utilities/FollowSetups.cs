using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IFollowCommandRepository GetCommandRepository()
		{
			return serviceProvider.GetRequiredService<IFollowCommandRepository>();
		}

		public IFollowIncludeBuilderFactory GetIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IFollowIncludeBuilderFactory>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IFollowCommandRepository GetCommandRepository()
		{
			return serviceScope.ServiceProvider.GetCommandRepository();
		}

		public IFollowIncludeBuilderFactory GetIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetIncludeBuilderFactory();
		}

		public async Task<Follow?> GetByIdAsync(
			FollowId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetIncludeBuilderFactory().Create().WithFollower().WithFollowing().Build();

			return await serviceScope.GetCommandRepository().GetByIdAsync(id, include, cancellationToken);
		}

		public async Task AddAsync(
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetCommandRepository().AddAsync(follow, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetCommandRepository().AddRangeAsync(follows, cancellationToken);
		}

		public async Task DeleteAsync(
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetCommandRepository().DeleteAsync(follow, cancellationToken);
		}
	}
}
