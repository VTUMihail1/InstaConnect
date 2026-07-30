using InstaConnect.Identity.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Tests.Features.UserClaims.Extensions;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.UserClaims.Utilities;

public abstract class BaseUserClaimPresentationCommandFunctionalTest : BaseUserClaimWebTest
{
	protected IUserClaimClient Client { get; }

	protected IUserClaimEventClient EventClient { get; }

	protected BaseUserClaimPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreateUserClaimClient();
		EventClient = webApplicationFactory.CreateUserClaimEventClient();
	}

	protected override async Task OnInitializeAsync()
	{
		await base.OnInitializeAsync();
		await EventClient.StartAsync(CancellationToken);
	}

	protected override async Task OnDisposeAsync()
	{
		await EventClient.StopAsync(CancellationToken);
	}
}
