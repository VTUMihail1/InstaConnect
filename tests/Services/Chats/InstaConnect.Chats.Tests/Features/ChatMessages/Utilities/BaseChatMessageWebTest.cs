using InstaConnect.Chats.Tests.Features.Common.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageWebTest : BaseChatMessageTest, IClassFixture<ChatsWebApplicationFactory>, IAsyncLifetime
{
	protected IServiceScope ServiceScope { get; }

	protected BaseChatMessageWebTest(ChatsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}

	public async Task InitializeAsync()
	{
		await ServiceScope.ResetChatsDatabaseAsync(CancellationToken);
		await OnInitializeAsync();
	}

	public async Task DisposeAsync()
	{
		await OnDisposeAsync();
		await ServiceScope.ResetChatsDatabaseAsync(CancellationToken);
	}

	protected virtual Task OnInitializeAsync()
	{
		return Task.CompletedTask;
	}

	protected virtual Task OnDisposeAsync()
	{
		return Task.CompletedTask;
	}
}
