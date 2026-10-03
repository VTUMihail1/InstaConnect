namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationCommandIntegrationTest : BasePostCommentLikeWebTest
{
	protected PostCommentLikeController Controller { get; }

	protected IPostCommentLikeEventClient CommentLikeEventClient { get; }

	protected BasePostCommentLikePresentationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostCommentLikeController();
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
