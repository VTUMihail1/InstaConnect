using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Extensions;

namespace InstaConnect.Follows.Application.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowApplicationCommandIntegrationTest : BaseFollowWebTest
{
	protected IApplicationSender Sender { get; }

	protected IFollowNotificationClient NotificationClient { get; }

	protected BaseFollowApplicationCommandIntegrationTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		NotificationClient = webApplicationFactory.CreateFollowNotificationClient(Following.Id);
	}
}
