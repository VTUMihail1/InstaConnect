using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Extensions;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.ChatMessages.Utilities;

public abstract class BaseChatMessagePresentationQueryFunctionalTest : BaseChatMessageWebTest
{
	protected IChatMessageApiClient ApiClient { get; }

	protected BaseChatMessagePresentationQueryFunctionalTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		ApiClient = webApplicationFactory.CreateMessageApiClient();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ParticipantOnes, CancellationToken);
		await ServiceScope.AddRangeAsync(ParticipantTwos, CancellationToken);
		await ServiceScope.AddRangeAsync(Chats, CancellationToken);
		await OnInitializeAsync();
	}
}
