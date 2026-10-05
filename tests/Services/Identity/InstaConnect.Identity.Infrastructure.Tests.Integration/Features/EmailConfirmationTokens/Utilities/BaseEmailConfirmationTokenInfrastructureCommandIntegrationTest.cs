using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenInfrastructureCommandIntegrationTest : BaseEmailConfirmationTokenWebTest
{
	protected IEmailConfirmationTokenCommandRepository Repository { get; }

	protected IEmailConfirmationTokenIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseEmailConfirmationTokenInfrastructureCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetEmailConfirmationTokenCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetEmailConfirmationTokenIncludeBuilderFactory();
	}
}
