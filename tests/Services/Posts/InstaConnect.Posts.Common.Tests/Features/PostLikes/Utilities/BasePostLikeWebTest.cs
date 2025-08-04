using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Events;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;

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
        await ServiceScope.ResetPostLikeDatabase(CancellationToken);
        await OnInitializeAsync();
        await EventHarness.StartAsync(CancellationToken);
    }

    public async Task DisposeAsync()
    {
        await ServiceScope.ResetPostLikeDatabase(CancellationToken);
        await EventHarness.StopAsync(CancellationToken);
    }

    protected abstract Task OnInitializeAsync();
}
