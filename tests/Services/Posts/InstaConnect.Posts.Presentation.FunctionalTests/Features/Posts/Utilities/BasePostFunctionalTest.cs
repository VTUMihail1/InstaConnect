namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Utilities;

public abstract class BasePostFunctionalTest : PostWebTest
{
    protected HttpClient HttpClient { get; }

    protected BasePostFunctionalTest(PostWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
