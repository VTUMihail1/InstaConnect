using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostComments.Utilities;

public abstract class BasePostCommentPresentationCommandFunctionalTest : BasePostCommentWebTest
{
	protected IPostCommentClient Client { get; }

	protected BasePostCommentPresentationCommandFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreatePostCommentClient();
	}
}
