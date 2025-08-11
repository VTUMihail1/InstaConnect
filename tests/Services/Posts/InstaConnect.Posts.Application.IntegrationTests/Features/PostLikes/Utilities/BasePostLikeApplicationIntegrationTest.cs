using InstaConnect.Common.Application.Abstractions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostLikes.Application.IntegrationTests.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationIntegrationTest : BasePostLikeWebTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected BasePostLikeApplicationIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        ApplicationSender = ServiceScope.GetApplicationSender();
    }
}
