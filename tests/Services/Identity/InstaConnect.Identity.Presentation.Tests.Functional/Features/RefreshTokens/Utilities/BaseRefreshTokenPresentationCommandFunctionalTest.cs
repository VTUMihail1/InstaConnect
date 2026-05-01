using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenPresentationCommandFunctionalTest : BaseRefreshTokenWebTest
{
	protected IRefreshTokenClient Client { get; }

	protected BaseRefreshTokenPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreateRefreshTokenClient();
	}
}
