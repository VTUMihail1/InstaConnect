namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Utilities;

public abstract class BaseUserPresentationQueryFunctionalTest : BaseUserWebTest
{
	protected HttpClient HttpClient { get; }

	protected BaseUserPresentationQueryFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		HttpClient = webApplicationFactory.CreateClient();
	}
}
