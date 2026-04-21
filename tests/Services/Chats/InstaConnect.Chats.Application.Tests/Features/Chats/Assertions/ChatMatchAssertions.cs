using InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Assertions;

public static class ChatMatchAssertions
{
    extension(AddChatCommandResponse response)
    {
        public void ShouldSatisfy(Chat chat, AddChatCommandRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(chat, request));
        }
    }

    extension(GetChatByIdQueryResponse response)
    {
        public void ShouldSatisfy(Chat chat, GetChatByIdQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(chat, request));
        }

        public void ShouldSatisfyInverted(Chat chat, GetChatByIdQueryRequest request)
        {
            response.ShouldSatisfy(p => p.MatchesInverted(chat, request));
        }
    }

    extension(GetAllChatsQueryResponse response)
    {
        public void ShouldSatisfy(
        User participantOne,
        ICollection<Chat> chats,
        GetAllChatsQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(participantOne, chats, request));
        }

        public void ShouldSatisfy(
            User participantOne,
            ICollection<Chat> chats,
            GetAllChatsQueryRequest request,
            ISortEnumTermTransformer<Chat> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(participantOne, chats, request, termTransformer));
        }

        public void ShouldSatisfyInverted(
        User participantTwo,
        ICollection<Chat> chats,
        GetAllChatsQueryRequest request)
        {
            response.ShouldSatisfy(p => p.MatchesInverted(participantTwo, chats, request));
        }

        public void ShouldSatisfyInverted(
            User participantTwo,
            ICollection<Chat> chats,
            GetAllChatsQueryRequest request,
            ISortEnumTermTransformer<Chat> termTransformer)
        {
            response.ShouldSatisfy(p => p.MatchesInverted(participantTwo, chats, request, termTransformer));
        }
    }

    extension(Chat chat)
    {
        public void ShouldSatisfy(AddChatCommandRequest request)
        {
            chat.ShouldSatisfy(p => p.Matches(request));
        }
    }
}
