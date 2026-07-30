using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenPresentationCommandFunctionalTest : BaseEmailConfirmationTokenWebTest
{
	protected IEmailConfirmationTokenClient Client { get; }

	protected IEmailConfirmationTokenEventClient EventClient { get; }

	protected BaseEmailConfirmationTokenPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreateEmailConfirmationTokenClient();
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
