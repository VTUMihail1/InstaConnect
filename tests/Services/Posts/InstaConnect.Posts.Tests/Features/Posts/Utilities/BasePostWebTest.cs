using InstaConnect.Posts.Tests.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public abstract class BasePostWebTest : BasePostTest, IClassFixture<PostsWebApplicationFactory>, IAsyncLifetime
{
    protected IServiceScope ServiceScope { get; }

    protected IEventHarness EventHarness { get; }

    protected BasePostWebTest(PostsWebApplicationFactory webApplicationFactory)
    {
        ServiceScope = webApplicationFactory.Services.CreateScope();
        EventHarness = ServiceScope.GetEventHarness();
    }

    public async Task InitializeAsync()
    {
        await EventHarness.StartAsync(CancellationToken);
        await ServiceScope.ResetPostDatabase(CancellationToken);
        await OnInitializeAsync();
    }

    public async Task DisposeAsync()
    {
        await ServiceScope.ResetPostDatabase(CancellationToken);
        await EventHarness.StopAsync(CancellationToken);
    }

    protected abstract Task OnInitializeAsync();
}
