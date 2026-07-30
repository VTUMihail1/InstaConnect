using InstaConnect.Identity.Tests.Features.Users.Abstractions;
using InstaConnect.Identity.Tests.Features.Users.Helpers;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Tests.Features.Users.Extensions;

public static class IdentityWebApplicationFactoryExtensions
{
	extension(IdentityWebApplicationFactory webApplicationFactory)
	{
		public IUserEventClient CreateUserEventClient()
		{
			var eventHarness = webApplicationFactory.Services.GetEventHarness();

			return new UserEventClient(eventHarness);
		}
	}
}
