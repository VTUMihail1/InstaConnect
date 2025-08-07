using InstaConnect.Common.Application.Abstractions;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostComments.Application.IntegrationTests.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationIntegrationTest : BasePostCommentWebTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected BasePostCommentApplicationIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        ApplicationSender = ServiceScope.GetApplicationSender();
    }
}
