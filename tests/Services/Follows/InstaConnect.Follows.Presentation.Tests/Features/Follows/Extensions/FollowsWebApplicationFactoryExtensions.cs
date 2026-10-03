using InstaConnect.Follows.Presentation.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Helpers;
using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Extensions;

public static class FollowsWebApplicationFactoryExtensions
{
	extension(FollowsWebApplicationFactory webApplicationFactory)
	{
		public IFollowApiClient CreateApiClient()
		{
			return new FollowApiClient(webApplicationFactory.CreateClient(), webApplicationFactory.Services.GetBaseAccessTokenGenerator());
		}
	}
}
