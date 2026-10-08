using InstaConnect.Follows.Presentation.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Extensions;

namespace InstaConnect.Follows.Presentation.Tests.Functional.Features.Follows.Utilities;

public abstract class BaseFollowPresentationQueryFunctionalTest : BaseFollowWebTest
{
	protected IFollowApiClient ApiClient { get; }

	protected BaseFollowPresentationQueryFunctionalTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		ApiClient = webApplicationFactory.CreateApiClient();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Followers, CancellationToken);
		await ServiceScope.AddRangeAsync(Followings, CancellationToken);
		await OnInitializeAsync();
	}
}
