using InstaConnect.Identity.Presentation.Tests.Features.Users.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Extensions;

public static class IdentityWebApplicationFactoryExtensions
{
	extension(IdentityWebApplicationFactory webApplicationFactory)
	{
		public IUserClient CreateUserClient()
		{
			return new UserClient(webApplicationFactory.CreateClient(), webApplicationFactory.Services.GetBaseAccessTokenGenerator());
		}
	}
}
