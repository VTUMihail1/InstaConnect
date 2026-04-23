using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationCommandIntegrationTest : BasePostCommentWebTest
{
    protected IApplicationSender Sender { get; }

    protected BasePostCommentApplicationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        Sender = ServiceScope.GetSender();
    }
}
