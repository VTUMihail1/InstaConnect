using InstaConnect.Identity.Tests.Features.Users.Abstractions;
using InstaConnect.Identity.Tests.Features.Users.Extensions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserPresentationCommandIntegrationTest : BaseUserWebTest
{
	protected UserController Controller { get; }

	protected IUserEventClient EventClient { get; }

	protected IEmailConfirmationTokenEventClient EmailConfirmationTokenEventClient { get; }

	protected BaseUserPresentationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetUserController();
		EventClient = webApplicationFactory.CreateEventClient();
		EmailConfirmationTokenEventClient = webApplicationFactory.CreateEmailConfirmationTokenEventClient();
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
