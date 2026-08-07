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

	protected override async Task OnInitializeAsync()
	{
		await base.OnInitializeAsync();
		await CommentEventClient.StartAsync(CancellationToken);
	}

	protected override async Task OnDisposeAsync()
	{
		await CommentEventClient.StopAsync(CancellationToken);
	}
}
