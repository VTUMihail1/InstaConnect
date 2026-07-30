using InstaConnect.Posts.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Extensions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationCommandIntegrationTest : BasePostLikeWebTest
{
	protected IApplicationSender Sender { get; }

	protected IPostLikeEventClient EventClient { get; }

	protected BasePostLikeApplicationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		EventClient = webApplicationFactory.CreatePostLikeEventClient();
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
