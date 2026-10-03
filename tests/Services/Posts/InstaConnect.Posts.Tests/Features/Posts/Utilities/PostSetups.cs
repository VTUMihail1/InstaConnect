using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommandRepository GetPostCommandRepository()
		{
			return serviceProvider.GetRequiredService<IPostCommandRepository>();
		}

		public IPostIncludeBuilderFactory GetPostIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IPostIncludeBuilderFactory>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostCommandRepository GetPostCommandRepository()
		{
			return serviceScope.ServiceProvider.GetPostCommandRepository();
		}

		public IPostIncludeBuilderFactory GetPostIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetPostIncludeBuilderFactory();
		}

		public async Task<Post?> GetByIdAsync(
			PostId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();

			return (await serviceScope.GetPostCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetUser();
		}

		public async Task AddAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommandRepository().AddAsync(post, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommandRepository().AddRangeAsync(posts, cancellationToken);
		}

		public async Task DeleteAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommandRepository().DeleteAsync(post, cancellationToken);
		}
	}
}
