using InstaConnect.Identity.Tests.Features.Common.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public abstract class BaseUserClaimWebTest : BaseUserClaimTest, IClassFixture<IdentityWebApplicationFactory>, IAsyncLifetime
{
	protected IServiceScope ServiceScope { get; }

	protected BaseUserClaimWebTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory.Services.GetPasswordHasher())
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}

	public async Task InitializeAsync()
	{
		await ServiceScope.ResetIdentityDatabaseAsync(CancellationToken);
		await OnInitializeAsync();
	}

	public async Task DisposeAsync()
	{
		await OnDisposeAsync();
		await ServiceScope.ResetIdentityDatabaseAsync(CancellationToken);
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
