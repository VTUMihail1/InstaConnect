namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Utilities;

public abstract class BaseUserPresentationCommandFunctionalTest : BaseUserWebTest
{
    protected HttpClient HttpClient { get; }

    protected BaseUserPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
