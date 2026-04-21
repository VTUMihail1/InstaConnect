using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMatchAssertions
{
    extension(AddChatMessageApiResponse response)
    {
        public void ShouldSatisfy(
        ChatMessage chatMessage,
        AddChatMessageApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(chatMessage, request));
        }
    }

    extension(UpdateChatMessageApiResponse response)
    {
        public void ShouldSatisfy(
        ChatMessage chatMessage,
        UpdateChatMessageApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(chatMessage, request));
        }
    }

    extension(GetChatMessageByIdApiResponse response)
    {
        public void ShouldSatisfy(
        ChatMessage chatMessage,
        GetChatMessageByIdApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(chatMessage, request));
        }

        public void ShouldSatisfyInverted(ChatMessage chatMessage, GetChatMessageByIdApiRequest request)
        {
            response.ShouldSatisfy(p => p.MatchesInverted(chatMessage, request));
        }
    }

    extension(GetAllChatMessagesApiResponse response)
    {
        public void ShouldSatisfy(
        Chat chat,
        ICollection<ChatMessage> chatMessages,
        GetAllChatMessagesApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(chat, chatMessages, request));
        }

        public void ShouldSatisfy(
            Chat chat,
            ICollection<ChatMessage> chatMessages,
            GetAllChatMessagesApiRequest request,
            ISortEnumTermTransformer<ChatMessage> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(chat, chatMessages, request, termTransformer));
        }

        public void ShouldSatisfyInverted(Chat chat, ICollection<ChatMessage> chatMessages, GetAllChatMessagesApiRequest request)
        {
            response.ShouldSatisfy(p => p.MatchesInverted(chat, chatMessages, request));
        }

        public void ShouldSatisfyInverted(Chat chat, ICollection<ChatMessage> chatMessages, GetAllChatMessagesApiRequest request, ISortEnumTermTransformer<ChatMessage> termTransformer)
        {
            response.ShouldSatisfy(p => p.MatchesInverted(chat, chatMessages, request, termTransformer));
        }
    }

    extension(ActionResult<AddChatMessageApiResponse> response)
    {
        public void ShouldSatisfy(
        ChatMessage chatMessage,
        AddChatMessageApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(chatMessage, request));
        }
    }

    extension(ActionResult<UpdateChatMessageApiResponse> response)
    {
        public void ShouldSatisfy(
        ChatMessage chatMessage,
        UpdateChatMessageApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(chatMessage, request));
        }
    }

    extension(ActionResult<GetChatMessageByIdApiResponse> response)
    {
        public void ShouldSatisfy(
        ChatMessage chatMessage,
        GetChatMessageByIdApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(chatMessage, request));
        }
    }

    extension(ActionResult<GetAllChatMessagesApiResponse> response)
    {
        public void ShouldSatisfy(
        Chat chat,
        ICollection<ChatMessage> chatMessages,
        GetAllChatMessagesApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(chat, chatMessages, request));
        }
    }

    extension(ChatMessage chatMessage)
    {
        public void ShouldSatisfy(AddChatMessageApiRequest request)
        {
            chatMessage.ShouldSatisfy(p => p.Matches(request));
        }

        public void ShouldSatisfyInverted(AddChatMessageApiRequest request)
        {
            chatMessage.ShouldSatisfy(p => p.MatchesInverted(request));
        }

        public void ShouldSatisfy(UpdateChatMessageApiRequest request)
        {
            chatMessage.ShouldSatisfy(p => p.Matches(request));
        }

        public void ShouldSatisfyInverted(UpdateChatMessageApiRequest request)
        {
            chatMessage.ShouldSatisfy(p => p.MatchesInverted(request));
        }
    }
}
