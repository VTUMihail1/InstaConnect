using InstaConnect.Follows.Presentation.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Extensions;

namespace InstaConnect.Follows.Presentation.Tests.Functional.Features.Follows.Utilities;

public abstract class BaseFollowPresentationCommandFunctionalTest : BaseFollowWebTest
{
	protected IFollowClient Client { get; }

	protected BaseFollowPresentationCommandFunctionalTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreateFollowClient();
	}
}
