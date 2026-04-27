using InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMatchAssertions
{
    extension(AddChatMessageCommandResponse response)
    {
        public void ShouldSatisfy(ChatMessage chatMessage, AddChatMessageCommandRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(chatMessage, request));
        }
    }

    extension(UpdateChatMessageCommandResponse response)
    {
        public void ShouldSatisfy(ChatMessage chatMessage, UpdateChatMessageCommandRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(chatMessage, request));
        }
    }

    extension(GetChatMessageByIdQueryResponse response)
    {
        public void ShouldSatisfy(ChatMessage chatMessage, GetChatMessageByIdQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(chatMessage, request));
        }

        public void ShouldSatisfyInverted(ChatMessage chatMessage, GetChatMessageByIdQueryRequest request)
        {
            response.ShouldSatisfy(p => p.MatchesInverted(chatMessage, request));
        }
    }

    extension(GetAllChatMessagesQueryResponse response)
    {
        public void ShouldSatisfy(Chat chat, ICollection<ChatMessage> chatMessages, GetAllChatMessagesQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(chat, chatMessages, request));
        }

        public void ShouldSatisfy(Chat chat, ICollection<ChatMessage> chatMessages, GetAllChatMessagesQueryRequest request, ISortEnumTermTransformer<ChatMessage> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(chat, chatMessages, request, termTransformer));
        }

        public void ShouldSatisfyInverted(Chat chat, ICollection<ChatMessage> chatMessages, GetAllChatMessagesQueryRequest request)
        {
            response.ShouldSatisfy(p => p.MatchesInverted(chat, chatMessages, request));
        }

        public void ShouldSatisfyInverted(Chat chat, ICollection<ChatMessage> chatMessages, GetAllChatMessagesQueryRequest request, ISortEnumTermTransformer<ChatMessage> termTransformer)
        {
            response.ShouldSatisfy(p => p.MatchesInverted(chat, chatMessages, request, termTransformer));
        }
    }

    extension(ChatMessage chatMessage)
    {
        public void ShouldSatisfy(AddChatMessageCommandRequest request)
        {
            chatMessage.ShouldSatisfy(p => p.Matches(request));
        }

        public void ShouldSatisfy(UpdateChatMessageCommandRequest request)
        {
            chatMessage.ShouldSatisfy(p => p.Matches(request));
        }

        public void ShouldSatisfyInverted(AddChatMessageCommandRequest request)
        {
            chatMessage.ShouldSatisfy(p => p.MatchesInverted(request));
        }

        public void ShouldSatisfyInverted(UpdateChatMessageCommandRequest request)
        {
            chatMessage.ShouldSatisfy(p => p.MatchesInverted(request));
        }
    }
}
