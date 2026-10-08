using InstaConnect.Identity.Tests.Features.Common.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public abstract class BaseUserClaimWebTest : BaseUserClaimTest, IClassFixture<IdentityWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseUserClaimWebTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory.Services.GetPasswordHasher())
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
