using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenPresentationCommandFunctionalTest : BaseRefreshTokenWebTest
{
	protected IRefreshTokenApiClient RefreshTokenApiClient { get; }

	protected BaseRefreshTokenPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		RefreshTokenApiClient = webApplicationFactory.CreateRefreshTokenApiClient();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(UserClaim, CancellationToken);
		await OnInitializeAsync();
	}
}
