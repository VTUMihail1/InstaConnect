namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenPresentationCommandFunctionalTest : BaseEmailConfirmationTokenWebTest
{
    protected HttpClient HttpClient { get; }

    protected BaseEmailConfirmationTokenPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
