namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeApplicationCommandIntegrationTest : BasePostCommentLikeWebTest
{
    protected IApplicationSender Sender { get; }

    protected BasePostCommentLikeApplicationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        Sender = ServiceScope.GetSender();
    }
}
