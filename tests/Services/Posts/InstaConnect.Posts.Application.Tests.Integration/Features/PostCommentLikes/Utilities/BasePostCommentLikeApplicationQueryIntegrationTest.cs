using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeApplicationQueryIntegrationTest : BasePostCommentLikeWebTest
{
    protected IApplicationSender Sender { get; }

    protected BasePostCommentLikeApplicationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        Sender = ServiceScope.GetSender();
    }
}
