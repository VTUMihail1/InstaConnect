using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Tests.Features.Utilities;
using InstaConnect.Follows.Infrastructure.Tests.Features.Users.Abstractions;
using InstaConnect.Follows.Infrastructure.Tests.Features.Users.Extensions;

namespace InstaConnect.Follows.Infrastructure.Tests.Functional.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandFunctionalTest : BaseUserWebTest
{
	protected IUserEventClient UserEventClient { get; }

	protected IEventPublisher EventPublisher { get; }

	protected BaseUserInfrastructureCommandFunctionalTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		UserEventClient = webApplicationFactory.CreateUserEventClient();
		EventPublisher = ServiceScope.GetEventPublisher();
	}

	protected override async Task OnInitializeAsync()
	{
		await base.OnInitializeAsync();
		await UserEventClient.StartAsync(CancellationToken);
	}

	protected override async Task OnDisposeAsync()
	{
		await UserEventClient.StopAsync(CancellationToken);
	}
}
