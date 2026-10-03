using InstaConnect.Posts.Tests.Features.Posts.Abstractions;
using InstaConnect.Posts.Tests.Features.Posts.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostPresentationCommandIntegrationTest : BasePostWebTest
{
	protected PostController Controller { get; }

	protected IPostEventClient EventClient { get; }

	protected BasePostPresentationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostController();
		EventClient = webApplicationFactory.CreateEventClient();
	}

	protected override async Task OnInitializeAsync()
	{
		await base.OnInitializeAsync();
		await EventClient.StartAsync(CancellationToken);
	}

	protected override async Task OnDisposeAsync()
	{
		await EventClient.StopAsync(CancellationToken);
	}
}
