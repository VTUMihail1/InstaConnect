using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public ChatMessageController GetChatMessageController()
		{
			return serviceProvider.GetRequiredService<ChatMessageController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public ChatMessageController GetChatMessageController()
		{
			return serviceScope.ServiceProvider.GetChatMessageController();
		}

		internal async Task<ChatMessage?> GetByIdAsync(
		ChatMessageIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new ChatMessageId(
							   new(
								   new(id.ParticipantOneId),
								   new(id.ParticipantTwoId)),
							   id.MessageId),
				cancellationToken);
		}

		public async Task<ChatMessage?> GetByIdAsync(
			AddChatMessageApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<ChatMessage?> GetByIdAsync(
			UpdateChatMessageApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<ChatMessage?> GetByIdAsync(
			ActionResult<AddChatMessageApiResponse> result,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				result.GetValue(),
				cancellationToken);
		}

		public async Task<ChatMessage?> GetByIdAsync(
			ActionResult<UpdateChatMessageApiResponse> result,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				result.GetValue(),
				cancellationToken);
		}
	}
}
