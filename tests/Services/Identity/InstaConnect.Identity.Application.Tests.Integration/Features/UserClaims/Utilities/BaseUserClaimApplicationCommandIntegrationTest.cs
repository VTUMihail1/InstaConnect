using InstaConnect.Identity.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Tests.Features.UserClaims.Extensions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimApplicationCommandIntegrationTest : BaseUserClaimWebTest
{
	protected IApplicationSender Sender { get; }

	protected IUserClaimEventClient ClaimEventClient { get; }

	protected BaseUserClaimApplicationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		ClaimEventClient = webApplicationFactory.CreateClaimEventClient();
	}

	protected override async Task OnInitializeAsync()
	{
		await base.OnInitializeAsync();
		await ClaimEventClient.StartAsync(CancellationToken);
	}

	protected override async Task OnDisposeAsync()
	{
		await ClaimEventClient.StopAsync(CancellationToken);
	}
}
