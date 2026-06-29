using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostDomainCommandIntegrationTest : BasePostWebTest
{
	protected IPostCommandService Service { get; }

	protected BasePostDomainCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetPostCommandService();
	}
}
