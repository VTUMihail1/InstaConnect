using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Follows.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Options;
using InstaConnect.Follows.Tests.Features.Common.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Helpers;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InstaConnect.Follows.Tests.Features.Follows.Extensions;

public static class FollowsWebApplicationFactoryExtensions
{
	extension(FollowsWebApplicationFactory webApplicationFactory)
	{
		public IFollowNotificationClient CreateNotificationClient(UserId followingId)
		{
			var hubRoute = webApplicationFactory.Services
				.GetRequiredService<IOptions<FollowOptions>>()
				.Value
				.HubRoute;

			var connection = webApplicationFactory.CreateHubConnection(followingId.Id, hubRoute.TrimStartSlash());

			return new FollowNotificationClient(connection);
		}

		public IFollowEventClient CreateEventClient()
		{
			var eventHarness = webApplicationFactory.Services.GetEventHarness();

			return new FollowEventClient(eventHarness);
		}
	}
}
