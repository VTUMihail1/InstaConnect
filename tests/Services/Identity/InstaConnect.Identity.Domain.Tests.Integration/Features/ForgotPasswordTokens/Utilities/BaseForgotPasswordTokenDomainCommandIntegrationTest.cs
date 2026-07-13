using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenDomainCommandIntegrationTest : BaseForgotPasswordTokenWebTest
{
	protected IForgotPasswordTokenCommandService Service { get; }

	protected BaseForgotPasswordTokenDomainCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Service = ServiceScope.GetForgotPasswordTokenCommandService();
	}
}
