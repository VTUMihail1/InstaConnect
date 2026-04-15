using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageSetups
{
    extension(IServiceScope serviceScope)
    {
        public async Task<ChatMessage?> GetChatMessageByIdAsync(
        ChatMessageIdApiResponse id,
        CancellationToken cancellationToken)
        {
            return await serviceScope.GetChatMessageByIdAsync(
                new ChatMessageId(
                               new(
                                   new(id.ParticipantOneId),
                                   new(id.ParticipantTwoId)),
                               id.MessageId),
                cancellationToken);
        }
    }
}
