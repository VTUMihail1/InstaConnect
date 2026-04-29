namespace InstaConnect.Follows.Presentation.Tests.Functional.Features.Follows.Utilities;

public abstract class BaseFollowPresentationQueryFunctionalTest : BaseFollowWebTest
{
	protected HttpClient HttpClient { get; }

	protected BaseFollowPresentationQueryFunctionalTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		HttpClient = webApplicationFactory.CreateClient();
	}
}
