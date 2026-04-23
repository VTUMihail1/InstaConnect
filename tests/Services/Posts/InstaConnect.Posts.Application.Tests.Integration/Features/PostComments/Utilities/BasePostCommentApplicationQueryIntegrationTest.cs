using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationQueryIntegrationTest : BasePostCommentWebTest
{
    protected IApplicationSender Sender { get; }

    protected BasePostCommentApplicationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        Sender = ServiceScope.GetSender();
    }
}
