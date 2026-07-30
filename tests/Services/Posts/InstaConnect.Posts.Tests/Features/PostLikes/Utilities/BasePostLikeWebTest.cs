using InstaConnect.Posts.Tests.Features.Common.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public abstract class BasePostLikeWebTest : BasePostLikeTest, IClassFixture<PostsWebApplicationFactory>, IAsyncLifetime
{
	protected IServiceScope ServiceScope { get; }

	protected BasePostLikeWebTest(PostsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}

	public async Task InitializeAsync()
	{
		await ServiceScope.ResetPostsDatabaseAsync(CancellationToken);
		await OnInitializeAsync();
	}

	public async Task DisposeAsync()
	{
		await OnDisposeAsync();
		await ServiceScope.ResetPostsDatabaseAsync(CancellationToken);
	}

	protected virtual Task OnInitializeAsync()
	{
		return Task.CompletedTask;
	}

	protected virtual Task OnDisposeAsync()
	{
		return Task.CompletedTask;
	}
}
