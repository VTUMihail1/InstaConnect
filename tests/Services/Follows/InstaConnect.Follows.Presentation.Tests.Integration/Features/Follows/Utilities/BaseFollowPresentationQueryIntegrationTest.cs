namespace InstaConnect.Follows.Presentation.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowPresentationQueryIntegrationTest : BaseFollowWebTest
{
	protected FollowController Controller { get; }

	protected FollowingFollowController FollowingController { get; }

	protected BaseFollowPresentationQueryIntegrationTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetFollowController();
		FollowingController = ServiceScope.GetFollowingFollowController();
	}
}
