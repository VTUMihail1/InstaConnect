using InstaConnect.Chats.Tests.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Extensions;

using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatApplicationCommandIntegrationTest : BaseChatWebTest
{
	protected IApplicationSender Sender { get; }

	protected IChatEventClient EventClient { get; }

	protected BaseChatApplicationCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		EventClient = webApplicationFactory.CreateEventClient();
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
