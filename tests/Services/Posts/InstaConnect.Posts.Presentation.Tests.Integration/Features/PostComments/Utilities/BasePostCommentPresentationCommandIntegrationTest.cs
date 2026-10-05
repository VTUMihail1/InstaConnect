namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentPresentationCommandIntegrationTest : BasePostCommentWebTest
{
	protected PostCommentController Controller { get; }

	protected IPostCommentEventClient CommentEventClient { get; }

	protected BasePostCommentPresentationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostCommentController();
		CommentEventClient = webApplicationFactory.CreateCommentEventClient();
	}

	public override async Task InitializeAsync()
	{
		await CommentEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await CommentEventClient.StopAsync(CancellationToken);
	}
}
