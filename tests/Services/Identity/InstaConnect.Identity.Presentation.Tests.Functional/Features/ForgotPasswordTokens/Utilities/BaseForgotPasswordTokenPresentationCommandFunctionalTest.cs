namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenPresentationCommandFunctionalTest : BaseForgotPasswordTokenWebTest
{
    protected HttpClient HttpClient { get; }

    protected BaseForgotPasswordTokenPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
