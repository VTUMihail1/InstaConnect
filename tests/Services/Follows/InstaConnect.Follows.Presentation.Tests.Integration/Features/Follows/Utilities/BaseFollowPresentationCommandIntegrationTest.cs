namespace InstaConnect.Follows.Presentation.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowPresentationCommandIntegrationTest : BaseFollowWebTest
{
	protected FollowController Controller { get; }

	protected IFollowEventClient EventClient { get; }

	protected IFollowNotificationClient NotificationClient { get; }

	protected BaseFollowPresentationCommandIntegrationTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetFollowController();
		EventClient = webApplicationFactory.CreateEventClient();
		NotificationClient = webApplicationFactory.CreateNotificationClient(Following.Id);
	}

	public override async Task InitializeAsync()
	{
		await EventClient.StartAsync(CancellationToken);
		await NotificationClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await EventClient.StopAsync(CancellationToken);
		await NotificationClient.StopAsync(CancellationToken);
	}
}
