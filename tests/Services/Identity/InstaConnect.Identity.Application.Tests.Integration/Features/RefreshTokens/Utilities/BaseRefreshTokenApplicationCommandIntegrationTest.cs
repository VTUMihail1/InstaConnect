using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenApplicationCommandIntegrationTest : BaseRefreshTokenWebTest
{
	protected IApplicationSender Sender { get; }

	protected BaseRefreshTokenApplicationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}
}
