using InstaConnect.Chats.Application.Features.Chats.Models;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;

public static class ChatSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<Chat?> GetChatByIdAsync(
		ChatIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatByIdAsync(
				new ChatId(new(id.ParticipantOneId), new(id.ParticipantTwoId)),
				cancellationToken);
		}
	}
}
