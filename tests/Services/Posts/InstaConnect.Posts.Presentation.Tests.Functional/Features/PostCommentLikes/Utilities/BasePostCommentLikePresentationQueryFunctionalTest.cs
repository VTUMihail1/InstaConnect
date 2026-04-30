using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationQueryFunctionalTest : BasePostCommentLikeWebTest
{
	protected IPostCommentLikeClient Client { get; }

	protected BasePostCommentLikePresentationQueryFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreatePostCommentLikeClient();
	}
}
