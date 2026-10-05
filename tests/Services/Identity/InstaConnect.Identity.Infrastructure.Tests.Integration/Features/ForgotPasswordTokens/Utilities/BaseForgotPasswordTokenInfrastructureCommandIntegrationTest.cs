using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenInfrastructureCommandIntegrationTest : BaseForgotPasswordTokenWebTest
{
	protected IForgotPasswordTokenCommandRepository Repository { get; }

	protected IForgotPasswordTokenIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseForgotPasswordTokenInfrastructureCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetForgotPasswordTokenCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetForgotPasswordTokenIncludeBuilderFactory();
	}
}
