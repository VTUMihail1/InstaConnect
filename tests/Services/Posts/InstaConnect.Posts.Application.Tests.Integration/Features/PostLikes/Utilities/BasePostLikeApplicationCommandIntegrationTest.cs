using InstaConnect.Posts.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Extensions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationCommandIntegrationTest : BasePostLikeWebTest
{
	protected IApplicationSender Sender { get; }

	protected IPostLikeEventClient LikeEventClient { get; }

	protected BasePostLikeApplicationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
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
