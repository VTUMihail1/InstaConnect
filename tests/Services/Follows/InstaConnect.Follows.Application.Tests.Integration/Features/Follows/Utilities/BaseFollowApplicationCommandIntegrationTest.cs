using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Extensions;

namespace InstaConnect.Follows.Application.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowApplicationCommandIntegrationTest : BaseFollowWebTest
{
	protected IApplicationSender Sender { get; }

	protected IFollowEventClient EventClient { get; }

	protected IFollowNotificationClient NotificationClient { get; }

	protected BaseFollowApplicationCommandIntegrationTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		EventClient = webApplicationFactory.CreateEventClient();
		NotificationClient = webApplicationFactory.CreateNotificationClient(Following.Id);
	}

	protected override async Task OnInitializeAsync()
	{
		await base.OnInitializeAsync();
		await EventClient.StartAsync(CancellationToken);
		await NotificationClient.StartAsync(CancellationToken);
	}

	protected override async Task OnDisposeAsync()
	{
		await EventClient.StopAsync(CancellationToken);
		await NotificationClient.StopAsync(CancellationToken);
	}
}
