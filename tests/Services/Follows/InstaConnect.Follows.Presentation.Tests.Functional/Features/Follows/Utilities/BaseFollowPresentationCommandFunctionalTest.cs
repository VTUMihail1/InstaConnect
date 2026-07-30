using InstaConnect.Follows.Presentation.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Extensions;
using InstaConnect.Follows.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Extensions;

namespace InstaConnect.Follows.Presentation.Tests.Functional.Features.Follows.Utilities;

public abstract class BaseFollowPresentationCommandFunctionalTest : BaseFollowWebTest
{
	protected IFollowApiClient ApiClient { get; }

	protected IFollowEventClient EventClient { get; }

	protected IFollowNotificationClient NotificationClient { get; }

	protected BaseFollowPresentationCommandFunctionalTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		ApiClient = webApplicationFactory.CreateApiClient();
		EventClient = webApplicationFactory.CreateEventClient();
		NotificationClient = webApplicationFactory.CreateNotificationClient(Following.Id);
	}

	protected override async Task OnInitializeAsync()
	{
		await EventClient.StartAsync(CancellationToken);
		await NotificationClient.StartAsync(CancellationToken);
	}

	protected override async Task OnDisposeAsync()
	{
		await EventClient.StopAsync(CancellationToken);
		await NotificationClient.StopAsync(CancellationToken);
	}
}
