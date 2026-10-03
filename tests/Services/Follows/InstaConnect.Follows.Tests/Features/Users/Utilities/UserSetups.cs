using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserCommandRepository GetUserCommandRepository()
		{
			return serviceProvider.GetRequiredService<IUserCommandRepository>();
		}

		public IUserIncludeBuilderFactory GetUserIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IUserIncludeBuilderFactory>();
		}

		public IFollowFollowerIncludeBuilderFactory GetFollowFollowerIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IFollowFollowerIncludeBuilderFactory>();
		}

		public IFollowFollowingIncludeBuilderFactory GetFollowFollowingIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IFollowFollowingIncludeBuilderFactory>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserCommandRepository GetUserCommandRepository()
		{
			return serviceScope.ServiceProvider.GetUserCommandRepository();
		}

		public IUserIncludeBuilderFactory GetUserIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetUserIncludeBuilderFactory();
		}

		public IFollowFollowerIncludeBuilderFactory GetFollowFollowerIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetFollowFollowerIncludeBuilderFactory();
		}

		public IFollowFollowingIncludeBuilderFactory GetFollowFollowingIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetFollowFollowingIncludeBuilderFactory();
		}

		public async Task<User?> GetByIdAsync(
			UserId id,
			CancellationToken cancellationToken)
		{
			var followFollowerInclude = serviceScope.GetFollowFollowerIncludeBuilderFactory().Create().WithFollower().Build();
			var followFollowingInclude = serviceScope.GetFollowFollowingIncludeBuilderFactory().Create().WithFollowing().Build();

			var include = serviceScope.GetUserIncludeBuilderFactory().Create().WithFollowFollowers(followFollowerInclude).WithFollowFollowings(followFollowingInclude).Build();

			return (await serviceScope.GetUserCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetFollowFollowers().SetFollowFollowings();
		}

		public async Task AddAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetUserCommandRepository().AddAsync(user, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<User> users,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetUserCommandRepository().AddRangeAsync(users, cancellationToken);
		}

		public async Task DeleteAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetUserCommandRepository().DeleteAsync(user, cancellationToken);
		}
	}
}
