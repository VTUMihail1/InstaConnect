using InstaConnect.Posts.Tests.Features.Common.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public abstract class BaseUserWebTest : BaseUserTest, IClassFixture<PostsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseUserWebTest(PostsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
