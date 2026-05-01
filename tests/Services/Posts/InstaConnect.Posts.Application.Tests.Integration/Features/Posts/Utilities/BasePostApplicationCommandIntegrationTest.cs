using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostApplicationCommandIntegrationTest : BasePostWebTest
{
	protected IApplicationSender Sender { get; }

	protected BasePostApplicationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}
}
