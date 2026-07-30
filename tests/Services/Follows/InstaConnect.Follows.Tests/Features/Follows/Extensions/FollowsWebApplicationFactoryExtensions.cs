using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Follows.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Follows.Presentation.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Common.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Helpers;

namespace InstaConnect.Follows.Tests.Features.Follows.Extensions;

public static class FollowsWebApplicationFactoryExtensions
{
	extension(FollowsWebApplicationFactory webApplicationFactory)
	{
		public IFollowNotificationClient CreateNotificationClient(UserId followingId)
		{
			var connection = webApplicationFactory.CreateHubConnection(followingId.Id, FollowRoutes.Hub.TrimStartSlash());

			return new FollowNotificationClient(connection);
		}

		public IFollowEventClient CreateEventClient()
		{
			var eventHarness = webApplicationFactory.Services.GetEventHarness();

			return new FollowEventClient(eventHarness);
		}
	}
}
