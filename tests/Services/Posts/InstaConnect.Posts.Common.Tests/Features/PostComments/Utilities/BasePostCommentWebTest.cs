using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Events;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;

public abstract class BasePostCommentWebTest : BasePostCommentTest, IClassFixture<PostsWebApplicationFactory>, IAsyncLifetime
{
    protected IServiceScope ServiceScope { get; }

    protected IEventHarness EventHarness { get; }

    protected BasePostCommentWebTest(PostsWebApplicationFactory webApplicationFactory)
    {
        ServiceScope = webApplicationFactory.Services.CreateScope();
        EventHarness = ServiceScope.GetEventHarness();
    }

    public async Task InitializeAsync()
    {
        await ServiceScope.ResetPostCommentDatabase(CancellationToken);
        await OnInitializeAsync();
        await EventHarness.StartAsync(CancellationToken);
    }

    public async Task DisposeAsync()
    {
        await ServiceScope.ResetPostCommentDatabase(CancellationToken);
        await EventHarness.StopAsync(CancellationToken);
    }

    protected abstract Task OnInitializeAsync();
}
