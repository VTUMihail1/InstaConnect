using InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

public static class ChatSetups
{
    extension(IServiceScope serviceScope)
    {
        public async Task<Chat?> GetChatByIdAsync(
        ChatIdApiResponse id,
        CancellationToken cancellationToken)
        {
            return await serviceScope.GetChatByIdAsync(
                new ChatId(new(id.ParticipantOneId), new(id.ParticipantTwoId)),
                cancellationToken);
        }
    }
}
