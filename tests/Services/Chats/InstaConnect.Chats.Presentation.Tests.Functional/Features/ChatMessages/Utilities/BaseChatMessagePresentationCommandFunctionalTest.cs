using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Extensions;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.ChatMessages.Utilities;

public abstract class BaseChatMessagePresentationCommandFunctionalTest : BaseChatMessageWebTest
{
	protected IChatMessageApiClient HttpClient { get; }

	protected IChatMessageNotificationClient MessageNotificationClient { get; }

	protected BaseChatMessagePresentationCommandFunctionalTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		HttpClient = webApplicationFactory.CreateMessageApiClient();
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
