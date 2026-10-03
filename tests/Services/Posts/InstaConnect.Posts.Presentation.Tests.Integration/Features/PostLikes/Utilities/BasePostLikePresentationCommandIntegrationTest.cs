namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationCommandIntegrationTest : BasePostLikeWebTest
{
	protected PostLikeController Controller { get; }

	protected IPostLikeEventClient LikeEventClient { get; }

	protected BasePostLikePresentationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostLikeController();
		LikeEventClient = webApplicationFactory.CreateLikeEventClient();
	}

	protected override async Task OnInitializeAsync()
	{
		await base.OnInitializeAsync();
		await LikeEventClient.StartAsync(CancellationToken);
	}

	protected override async Task OnDisposeAsync()
	{
		await LikeEventClient.StopAsync(CancellationToken);
	}
}
