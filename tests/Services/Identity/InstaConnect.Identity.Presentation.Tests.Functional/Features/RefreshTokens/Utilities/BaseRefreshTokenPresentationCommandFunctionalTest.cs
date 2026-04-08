namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenPresentationCommandFunctionalTest : BaseRefreshTokenWebTest
{
    protected HttpClient HttpClient { get; }

    protected BaseRefreshTokenPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
