using InstaConnect.Posts.Presentation.Tests.Features.Posts.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.Posts.Utilities;

public abstract class BasePostPresentationQueryFunctionalTest : BasePostWebTest
{
	protected IPostClient Client { get; }

	protected BasePostPresentationQueryFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreatePostClient();
	}
}
