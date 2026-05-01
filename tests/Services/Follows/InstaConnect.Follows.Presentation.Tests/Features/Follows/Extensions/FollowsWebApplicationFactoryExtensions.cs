using InstaConnect.Follows.Presentation.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Extensions;

public static class FollowsWebApplicationFactoryExtensions
{
	extension(FollowsWebApplicationFactory webApplicationFactory)
	{
		public IFollowClient CreateFollowClient()
		{
			return new FollowClient(webApplicationFactory.CreateClient(), webApplicationFactory.Services.GetBaseAccessTokenGenerator());
		}
	}
}
