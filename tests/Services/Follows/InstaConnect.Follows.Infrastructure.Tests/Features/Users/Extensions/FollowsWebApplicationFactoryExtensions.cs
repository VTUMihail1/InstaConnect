using InstaConnect.Follows.Infrastructure.Tests.Features.Users.Abstractions;
using InstaConnect.Follows.Infrastructure.Tests.Features.Users.Helpers;
using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Users.Extensions;

public static class FollowsWebApplicationFactoryExtensions
{
	extension(FollowsWebApplicationFactory webApplicationFactory)
	{
		public IUserEventClient CreateUserEventClient()
		{
			var eventHarness = webApplicationFactory.Services.GetEventHarness();

			return new UserEventClient(eventHarness);
		}
	}
}
