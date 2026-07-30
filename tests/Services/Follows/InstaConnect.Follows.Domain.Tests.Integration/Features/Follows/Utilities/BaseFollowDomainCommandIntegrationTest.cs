using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Extensions;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowDomainCommandIntegrationTest : BaseFollowWebTest
{
	protected IFollowCommandService Service { get; }

	protected IFollowEventClient EventClient { get; }

	protected IFollowNotificationClient NotificationClient { get; }

	protected BaseFollowDomainCommandIntegrationTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetFollowCommandService();
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
