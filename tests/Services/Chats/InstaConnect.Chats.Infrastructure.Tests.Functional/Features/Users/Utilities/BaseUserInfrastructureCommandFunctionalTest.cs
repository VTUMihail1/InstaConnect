using InstaConnect.Chats.Infrastructure.Tests.Features.Users.Abstractions;
using InstaConnect.Chats.Infrastructure.Tests.Features.Users.Extensions;
using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Tests.Features.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Functional.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandFunctionalTest : BaseUserWebTest
{
	protected IUserEventClient EventClient { get; }

	protected IEventPublisher EventPublisher { get; }

	protected BaseUserInfrastructureCommandFunctionalTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		EventClient = webApplicationFactory.CreateUserEventClient();
		EventPublisher = ServiceScope.GetEventPublisher();
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
