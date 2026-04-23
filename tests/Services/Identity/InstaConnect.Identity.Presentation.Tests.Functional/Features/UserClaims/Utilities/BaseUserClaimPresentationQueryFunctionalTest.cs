using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.UserClaims.Utilities;

public abstract class BaseUserClaimPresentationQueryFunctionalTest : BaseUserClaimWebTest
{
    protected HttpClient HttpClient { get; }

    protected BaseUserClaimPresentationQueryFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
