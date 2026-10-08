using InstaConnect.Follows.Tests.Features.Common.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Follows.Tests.Features.Users.Utilities;

public abstract class BaseUserWebTest : BaseUserTest, IClassFixture<FollowsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseUserWebTest(FollowsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
