using InstaConnect.Posts.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationCommandIntegrationTest : BasePostCommentWebTest
{
	protected IApplicationSender Sender { get; }

	protected IPostCommentEventClient EventClient { get; }

	protected BasePostCommentApplicationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		EventClient = webApplicationFactory.CreatePostCommentEventClient();
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
