using InstaConnect.Common.Application.Abstractions;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostCommentLikes.Application.IntegrationTests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeApplicationIntegrationTest : BasePostCommentLikeWebTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected BasePostCommentLikeApplicationIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        ApplicationSender = ServiceScope.GetApplicationSender();
    }
}
