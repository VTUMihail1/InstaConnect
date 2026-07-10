using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageDomainCommandIntegrationTest : BaseChatMessageWebTest
{
	protected IChatMessageCommandService Service { get; }

	protected IChatMessageNotificationClient NotificationClient { get; }

	protected BaseChatMessageDomainCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Service = ServiceScope.GetChatMessageCommandService();
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
