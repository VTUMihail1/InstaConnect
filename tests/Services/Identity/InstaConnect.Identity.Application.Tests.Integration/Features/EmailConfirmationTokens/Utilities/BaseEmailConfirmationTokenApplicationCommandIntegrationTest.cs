using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenApplicationCommandIntegrationTest : BaseEmailConfirmationTokenWebTest
{
	protected IApplicationSender Sender { get; }

	protected IEmailConfirmationTokenEventClient EventClient { get; }

	protected BaseEmailConfirmationTokenApplicationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		EventClient = webApplicationFactory.CreateEmailConfirmationTokenEventClient();
	}

	protected override async Task OnInitializeAsync()
	{
		await base.OnInitializeAsync();
		await EventClient.StartAsync(CancellationToken);
	}

	protected override async Task OnDisposeAsync()
	{
		await EventClient.StopAsync(CancellationToken);
	}
}
