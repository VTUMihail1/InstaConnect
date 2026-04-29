using InstaConnect.Chats.Infrastructure.Features.Common.Abstractions;
using InstaConnect.Common.Tests.Features.Extensions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Tests.Features.Common.Utilities;

public static class ChatsSetups
{

	extension(IServiceProvider serviceProvider)
	{
		public IChatsContext GetChatsContext()
		{
			return serviceProvider.GetRequiredService<IChatsContext>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IChatsContext GetChatsContext()
		{
			return serviceScope.ServiceProvider.GetChatsContext();
		}

		public async Task ResetChatsDatabase(
			CancellationToken cancellationToken)
		{
			var context = serviceScope.GetChatsContext();

			await context.ChatMessages.ResetAsync(cancellationToken);
			await context.Chats.ResetAsync(cancellationToken);
			await context.Users.ResetAsync(cancellationToken);
		}
	}
}
