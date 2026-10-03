using InstaConnect.Identity.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Tests.Features.UserClaims.Extensions;
using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimDomainCommandIntegrationTest : BaseUserClaimWebTest
{
	protected IUserClaimCommandService Service { get; }

	protected IUserClaimEventClient ClaimEventClient { get; }

	protected BaseUserClaimDomainCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Service = ServiceScope.GetClaimCommandService();
		ClaimEventClient = webApplicationFactory.CreateClaimEventClient();
	}

	protected override async Task OnInitializeAsync()
	{
		await base.OnInitializeAsync();
		await ClaimEventClient.StartAsync(CancellationToken);
	}

	protected override async Task OnDisposeAsync()
	{
		await ClaimEventClient.StopAsync(CancellationToken);
	}
}
