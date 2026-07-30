using InstaConnect.Identity.Tests.Features.Users.Abstractions;
using InstaConnect.Identity.Tests.Features.Users.Extensions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Utilities;

public abstract class BaseUserPresentationCommandFunctionalTest : BaseUserWebTest
{
	protected IUserClient Client { get; }

	protected IUserEventClient EventClient { get; }

	protected IEmailConfirmationTokenEventClient EmailConfirmationTokenEventClient { get; }

	protected BaseUserPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreateUserClient();
		EventClient = webApplicationFactory.CreateUserEventClient();
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
