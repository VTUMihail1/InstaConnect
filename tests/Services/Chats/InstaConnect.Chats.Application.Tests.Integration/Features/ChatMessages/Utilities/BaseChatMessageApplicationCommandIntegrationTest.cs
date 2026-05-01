using InstaConnect.Chats.Tests.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;

using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageApplicationCommandIntegrationTest : BaseChatMessageWebTest
{
	protected IApplicationSender Sender { get; }

	protected IChatMessageNotificationClient NotificationClient { get; }

	protected BaseChatMessageApplicationCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		NotificationClient = webApplicationFactory.CreateChatMessageNotificationClient(ParticipantTwo.Id);
	}

	protected override async Task OnInitializeAsync()
	{
		await NotificationClient.ConnectAsync(CancellationToken);
	}

	protected override async Task OnDisposeAsync()
	{
		await NotificationClient.DisconnectAsync(CancellationToken);
	}
}
