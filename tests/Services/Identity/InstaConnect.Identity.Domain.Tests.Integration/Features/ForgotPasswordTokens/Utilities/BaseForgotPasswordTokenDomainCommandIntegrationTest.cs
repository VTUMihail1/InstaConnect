using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenDomainCommandIntegrationTest : BaseForgotPasswordTokenWebTest
{
	protected IForgotPasswordTokenCommandService Service { get; }

	protected IForgotPasswordTokenEventClient ForgotPasswordTokenEventClient { get; }

	protected BaseForgotPasswordTokenDomainCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Service = ServiceScope.GetForgotPasswordTokenCommandService();
		ForgotPasswordTokenEventClient = webApplicationFactory.CreateForgotPasswordTokenEventClient();
	}

	protected override async Task OnInitializeAsync()
	{
		await base.OnInitializeAsync();
		await ForgotPasswordTokenEventClient.StartAsync(CancellationToken);
	}

	protected override async Task OnDisposeAsync()
	{
		await ForgotPasswordTokenEventClient.StopAsync(CancellationToken);
	}
}
