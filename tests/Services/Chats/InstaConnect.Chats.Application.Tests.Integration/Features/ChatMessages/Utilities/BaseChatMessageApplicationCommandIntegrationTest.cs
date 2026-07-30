using InstaConnect.Chats.Tests.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;

using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageApplicationCommandIntegrationTest : BaseChatMessageWebTest
{
	protected IApplicationSender Sender { get; }

	protected IChatMessageNotificationClient MessageNotificationClient { get; }

	protected BaseChatMessageApplicationCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		MessageNotificationClient = webApplicationFactory.CreateMessageNotificationClient(ParticipantTwo.Id);
	}

	protected override async Task OnInitializeAsync()
	{
		await base.OnInitializeAsync();
		await MessageNotificationClient.StartAsync(CancellationToken);
	}

	protected override async Task OnDisposeAsync()
	{
		await MessageNotificationClient.StopAsync(CancellationToken);
	}
}
