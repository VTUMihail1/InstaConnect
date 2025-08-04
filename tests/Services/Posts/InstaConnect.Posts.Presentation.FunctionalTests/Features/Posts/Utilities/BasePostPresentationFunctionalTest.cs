using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Utilities;

public abstract class BasePostPresentationFunctionalTest : BasePostWebTest
{
    protected HttpClient HttpClient { get; }

    protected BasePostPresentationFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
