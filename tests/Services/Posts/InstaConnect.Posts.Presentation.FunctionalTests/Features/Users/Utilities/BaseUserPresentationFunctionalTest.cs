using InstaConnect.Posts.Common.Tests.Features.Utilities;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Utilities;

public abstract class BaseUserPresentationFunctionalTest : BaseUserWebTest
{
    protected BasePostPresentationFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
    }
}
