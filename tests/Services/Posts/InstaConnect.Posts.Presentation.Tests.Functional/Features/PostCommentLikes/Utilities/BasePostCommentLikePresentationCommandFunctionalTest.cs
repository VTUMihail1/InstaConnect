using InstaConnect.Posts.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationCommandFunctionalTest : BasePostCommentLikeWebTest
{
	protected IPostCommentLikeApiClient CommentLikeApiClient { get; }

	protected IPostCommentLikeEventClient CommentLikeEventClient { get; }

	protected BasePostCommentLikePresentationCommandFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		CommentLikeApiClient = webApplicationFactory.CreateCommentLikeApiClient();
		CommentLikeEventClient = webApplicationFactory.CreateCommentLikeEventClient();
	}

	protected override async Task OnInitializeAsync()
	{
		await base.OnInitializeAsync();
		await CommentLikeEventClient.StartAsync(CancellationToken);
	}

	protected override async Task OnDisposeAsync()
	{
		await CommentLikeEventClient.StopAsync(CancellationToken);
	}
}
