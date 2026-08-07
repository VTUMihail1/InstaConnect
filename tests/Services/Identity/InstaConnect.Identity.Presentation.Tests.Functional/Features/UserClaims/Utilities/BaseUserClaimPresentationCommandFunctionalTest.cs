using InstaConnect.Identity.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Tests.Features.UserClaims.Extensions;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.UserClaims.Utilities;

public abstract class BaseUserClaimPresentationCommandFunctionalTest : BaseUserClaimWebTest
{
	protected IUserClaimApiClient ClaimApiClient { get; }

	protected IUserClaimEventClient ClaimEventClient { get; }

	protected BaseUserClaimPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		ClaimApiClient = webApplicationFactory.CreateClaimApiClient();
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
