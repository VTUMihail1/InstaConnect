using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public abstract class BaseUserWebTest : BaseUserTest, IClassFixture<IdentityWebApplicationFactory>, IAsyncLifetime
{
	protected IServiceScope ServiceScope { get; }

	protected IEventHarness EventHarness { get; }

	protected IImageHandler ImageHandler { get; }

	protected BaseUserWebTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory.Services.GetPasswordHasher())
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
		EventHarness = ServiceScope.GetEventHarness();
		ImageHandler = ServiceScope.GetImageHandler();
	}

	public async Task InitializeAsync()
	{
		await EventHarness.StartAsync(CancellationToken);
		await ServiceScope.ResetIdentityDatabase(CancellationToken);
		await OnInitializeAsync();
	}

	public async Task DisposeAsync()
	{
		await ServiceScope.ResetIdentityDatabase(CancellationToken);
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
