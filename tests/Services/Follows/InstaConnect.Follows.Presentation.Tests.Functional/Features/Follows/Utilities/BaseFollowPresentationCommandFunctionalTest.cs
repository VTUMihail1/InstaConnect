namespace InstaConnect.Follows.Presentation.Tests.Functional.Features.Follows.Utilities;

public abstract class BaseFollowPresentationCommandFunctionalTest : BaseFollowWebTest
{
	protected HttpClient HttpClient { get; }

	protected BaseFollowPresentationCommandFunctionalTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		HttpClient = webApplicationFactory.CreateClient();
	}
}
