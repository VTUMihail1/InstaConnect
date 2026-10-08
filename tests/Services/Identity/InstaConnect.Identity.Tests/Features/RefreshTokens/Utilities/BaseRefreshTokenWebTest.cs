using InstaConnect.Identity.Tests.Features.Common.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenWebTest : BaseRefreshTokenTest, IClassFixture<IdentityWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseRefreshTokenWebTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory.Services.GetPasswordHasher())
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
