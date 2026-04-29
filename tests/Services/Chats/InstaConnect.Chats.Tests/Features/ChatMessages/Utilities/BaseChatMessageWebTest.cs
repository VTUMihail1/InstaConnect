using InstaConnect.Chats.Tests.Features.Common.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageWebTest : BaseChatMessageTest, IClassFixture<ChatsWebApplicationFactory>, IAsyncLifetime
{
	protected IServiceScope ServiceScope { get; }

	protected IEventHarness EventHarness { get; }

	protected BaseChatMessageWebTest(ChatsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
		EventHarness = ServiceScope.GetEventHarness();
	}

	public async Task InitializeAsync()
	{
		await EventHarness.StartAsync(CancellationToken);
		await ServiceScope.ResetChatsDatabase(CancellationToken);
		await OnInitializeAsync();
	}

	public async Task DisposeAsync()
	{
		await ServiceScope.ResetChatsDatabase(CancellationToken);
		await EventHarness.StopAsync(CancellationToken);
	}

	protected abstract Task OnInitializeAsync();
}
