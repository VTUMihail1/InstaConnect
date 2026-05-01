using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Follows.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Follows.Presentation.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Common.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Tests.Features.Follows.Extensions;

public static class FollowsWebApplicationFactoryExtensions
{
	extension(FollowsWebApplicationFactory webApplicationFactory)
	{
		public IFollowNotificationClient CreateFollowNotificationClient(UserId followingId)
		{
			var connection = webApplicationFactory.CreateHubConnection(followingId.Id, FollowRoutes.Hub.TrimStart('/'));

			return new FollowNotificationClient(connection);
		}
	}
}
