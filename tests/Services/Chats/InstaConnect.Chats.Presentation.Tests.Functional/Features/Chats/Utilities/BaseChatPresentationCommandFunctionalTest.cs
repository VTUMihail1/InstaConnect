using InstaConnect.Chats.Presentation.Tests.Features.Chats.Abstractions;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Extensions;
using InstaConnect.Chats.Tests.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Extensions;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.Chats.Utilities;

public abstract class BaseChatPresentationCommandFunctionalTest : BaseChatWebTest
{
	protected IChatApiClient ApiClient { get; }

	protected IChatEventClient EventClient { get; }

	protected BaseChatPresentationCommandFunctionalTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		ApiClient = webApplicationFactory.CreateApiClient();
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

