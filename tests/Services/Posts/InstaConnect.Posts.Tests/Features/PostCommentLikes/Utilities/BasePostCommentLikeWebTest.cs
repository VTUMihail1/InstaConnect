using InstaConnect.Posts.Tests.Features.Common.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeWebTest : BasePostCommentLikeTest, IClassFixture<PostsWebApplicationFactory>, IAsyncLifetime
{
	protected IServiceScope ServiceScope { get; }

	protected IEventHarness EventHarness { get; }

	protected BasePostCommentLikeWebTest(PostsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
		EventHarness = ServiceScope.GetEventHarness();
	}

	public async Task InitializeAsync()
	{
		await EventHarness.StartAsync(CancellationToken);
		await ServiceScope.ResetPostsDatabase(CancellationToken);
		await OnInitializeAsync();
	}

	public async Task DisposeAsync()
	{
		await ServiceScope.ResetPostsDatabase(CancellationToken);
		await EventHarness.StopAsync(CancellationToken);
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
