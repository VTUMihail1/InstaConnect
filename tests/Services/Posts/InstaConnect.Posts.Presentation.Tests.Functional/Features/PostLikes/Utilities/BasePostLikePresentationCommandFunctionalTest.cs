using InstaConnect.Posts.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Extensions;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationCommandFunctionalTest : BasePostLikeWebTest
{
	protected IPostLikeApiClient LikeApiClient { get; }

	protected IPostLikeEventClient LikeEventClient { get; }

	protected BasePostLikePresentationCommandFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		LikeApiClient = webApplicationFactory.CreateLikeApiClient();
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
