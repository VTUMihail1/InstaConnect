namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimPresentationCommandIntegrationTest : BaseUserClaimWebTest
{
	protected UserClaimController Controller { get; }

	protected IUserClaimEventClient ClaimEventClient { get; }

	protected BaseUserClaimPresentationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetUserClaimController();
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
