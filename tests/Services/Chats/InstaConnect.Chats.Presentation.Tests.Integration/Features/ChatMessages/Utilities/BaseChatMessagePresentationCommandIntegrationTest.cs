namespace InstaConnect.Chats.Presentation.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessagePresentationCommandIntegrationTest : BaseChatMessageWebTest
{
	protected ChatMessageController Controller { get; }

	protected IChatMessageNotificationClient MessageNotificationClient { get; }

	protected BaseChatMessagePresentationCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetChatMessageController();
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
