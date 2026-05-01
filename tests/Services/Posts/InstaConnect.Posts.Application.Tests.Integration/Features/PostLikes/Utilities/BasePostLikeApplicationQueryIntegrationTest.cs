using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationQueryIntegrationTest : BasePostLikeWebTest
{
	protected IApplicationSender Sender { get; }

	protected BasePostLikeApplicationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}
}
