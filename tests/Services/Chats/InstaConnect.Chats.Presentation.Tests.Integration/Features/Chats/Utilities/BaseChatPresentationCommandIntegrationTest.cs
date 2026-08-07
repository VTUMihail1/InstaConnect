namespace InstaConnect.Chats.Presentation.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatPresentationCommandIntegrationTest : BaseChatWebTest
{
	protected ChatController Controller { get; }

	protected IChatEventClient EventClient { get; }

	protected BaseChatPresentationCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetChatController();
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
