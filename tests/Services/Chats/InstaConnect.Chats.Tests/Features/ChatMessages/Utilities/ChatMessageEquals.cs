using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.Utilities;
using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageEquals
{
    extension(ChatMessageId p)
    {
        public bool Matches(string participantOneId, string participantTwoId, string messageId)
        {
            return p.Id.Matches(participantOneId, participantTwoId) &&
                   p.MessageId.EqualsOrdinalIgnoreCase(messageId);
        }
    }
}
