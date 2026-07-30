using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenApplicationCommandIntegrationTest : BaseForgotPasswordTokenWebTest
{
	protected IApplicationSender Sender { get; }

	protected IForgotPasswordTokenEventClient ForgotPasswordTokenEventClient { get; }

	protected BaseForgotPasswordTokenApplicationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
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
