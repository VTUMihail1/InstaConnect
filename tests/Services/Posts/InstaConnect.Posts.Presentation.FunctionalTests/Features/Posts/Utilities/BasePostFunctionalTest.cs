using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Utilities;

public abstract class BasePostFunctionalTest : PostWebTest
{
    protected HttpClient HttpClient { get; }

    protected BasePostFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
