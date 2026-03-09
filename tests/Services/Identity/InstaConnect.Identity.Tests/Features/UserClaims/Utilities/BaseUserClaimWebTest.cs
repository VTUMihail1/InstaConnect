using InstaConnect.Identity.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public abstract class BaseUserClaimWebTest : BaseUserClaimTest, IClassFixture<IdentityWebApplicationFactory>, IAsyncLifetime
{
    protected IServiceScope ServiceScope { get; }

    protected IEventHarness EventHarness { get; }

    protected BaseUserClaimWebTest(IdentityWebApplicationFactory webApplicationFactory)
    {
        ServiceScope = webApplicationFactory.Services.CreateScope();
        EventHarness = ServiceScope.GetEventHarness();
    }

    public async Task InitializeAsync()
    {
        await EventHarness.StartAsync(CancellationToken);
        await ServiceScope.ResetUserDatabase(CancellationToken);
        await OnInitializeAsync();
    }

    public async Task DisposeAsync()
    {
        await ServiceScope.ResetUserDatabase(CancellationToken);
        await EventHarness.StopAsync(CancellationToken);
    }

    protected abstract Task OnInitializeAsync();
}
