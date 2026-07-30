using InstaConnect.Identity.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Tests.Features.UserClaims.Helpers;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Extensions;

public static class IdentityWebApplicationFactoryExtensions
{
	extension(IdentityWebApplicationFactory webApplicationFactory)
	{
		public IUserClaimEventClient CreateClaimEventClient()
		{
			var eventHarness = webApplicationFactory.Services.GetEventHarness();

			return new UserClaimEventClient(eventHarness);
		}
	}
}
