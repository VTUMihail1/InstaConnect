using InstaConnect.Posts.Tests.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public abstract class BasePostLikeWebTest : BasePostLikeTest, IClassFixture<PostsWebApplicationFactory>, IAsyncLifetime
{
    protected IServiceScope ServiceScope { get; }

    protected IEventHarness EventHarness { get; }

    protected BasePostLikeWebTest(PostsWebApplicationFactory webApplicationFactory)
    {
        ServiceScope = webApplicationFactory.Services.CreateScope();
        EventHarness = ServiceScope.GetEventHarness();
    }

    public async Task InitializeAsync()
    {
        await EventHarness.StartAsync(CancellationToken);
        await ServiceScope.ResetPostLikeDatabase(CancellationToken);
        await OnInitializeAsync();
    }

    public async Task DisposeAsync()
    {
        await ServiceScope.ResetPostLikeDatabase(CancellationToken);
        await EventHarness.StopAsync(CancellationToken);
    }

    protected abstract Task OnInitializeAsync();
}
