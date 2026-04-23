using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostApplicationCommandIntegrationTest : BasePostWebTest
{
    protected IApplicationSender Sender { get; }

    protected BasePostApplicationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        Sender = ServiceScope.GetSender();
    }
}
