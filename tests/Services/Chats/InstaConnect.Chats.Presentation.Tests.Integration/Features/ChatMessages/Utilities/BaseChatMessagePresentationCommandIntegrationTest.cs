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

	public override async Task InitializeAsync()
	{
		await MessageNotificationClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await MessageNotificationClient.StopAsync(CancellationToken);
	}
}
