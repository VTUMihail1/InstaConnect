using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

public static class ChatSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public ChatController GetChatController()
		{
			return serviceProvider.GetRequiredService<ChatController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public ChatController GetChatController()
		{
			return serviceScope.ServiceProvider.GetChatController();
		}

		internal async Task<Chat?> GetByIdAsync(
		ChatIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new ChatId(new(id.ParticipantOneId), new(id.ParticipantTwoId)),
				cancellationToken);
		}

		public async Task<Chat?> GetByIdAsync(
			AddChatApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<Chat?> GetByIdAsync(
			ActionResult<AddChatApiResponse> result,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				result.GetValue(),
				cancellationToken);
		}
	}
}
