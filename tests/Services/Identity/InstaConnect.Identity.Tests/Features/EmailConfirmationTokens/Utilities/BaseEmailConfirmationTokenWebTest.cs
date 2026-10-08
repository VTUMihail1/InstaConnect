using InstaConnect.Identity.Tests.Features.Common.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenWebTest : BaseEmailConfirmationTokenTest, IClassFixture<IdentityWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseEmailConfirmationTokenWebTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory.Services.GetPasswordHasher())
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
