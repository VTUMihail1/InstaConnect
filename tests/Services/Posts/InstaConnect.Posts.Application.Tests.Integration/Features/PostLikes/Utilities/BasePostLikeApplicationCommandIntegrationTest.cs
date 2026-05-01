using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationCommandIntegrationTest : BasePostLikeWebTest
{
	protected IApplicationSender Sender { get; }

	protected BasePostLikeApplicationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}
}
