using InstaConnect.Follows.Tests.Features.Common.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public abstract class BaseFollowWebTest : BaseFollowTest, IClassFixture<FollowsWebApplicationFactory>, IAsyncLifetime
{
	protected IServiceScope ServiceScope { get; }

	protected IEventHarness EventHarness { get; }

	protected BaseFollowWebTest(FollowsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
		EventHarness = ServiceScope.GetEventHarness();
	}

	public async Task InitializeAsync()
	{
		await EventHarness.StartAsync(CancellationToken);
		await ServiceScope.ResetFollowsDatabase(CancellationToken);
		await OnInitializeAsync();
	}

	public async Task DisposeAsync()
	{
		await ServiceScope.ResetFollowsDatabase(CancellationToken);
		await EventHarness.StopAsync(CancellationToken);
	}

	protected abstract Task OnInitializeAsync();
}
