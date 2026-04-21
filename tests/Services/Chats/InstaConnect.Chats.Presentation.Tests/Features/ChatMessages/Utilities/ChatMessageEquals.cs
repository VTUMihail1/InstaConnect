using InstaConnect.Chats.Application.Features.Users.Abstractions;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Presentation.Features.Users.Abstractions;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Presentation.Tests.Features.Users.Utilities;
using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageEquals
{
    extension(GetAllChatMessagesQueryRequest query)
    {
        public bool Matches(GetAllChatMessagesApiRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllChatMessagesQueryRequest, ChatMessagesSortTerm, GetAllChatMessagesApiRequest>(request) &&
                   query.MatchesPaginatable(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllChatMessagesApiRequest request)
        {
            return query.ParticipantTwoId == request.ParticipantTwoId;
        }
    }

    extension(GetChatMessageByIdQueryRequest query)
    {
        public bool Matches(GetChatMessageByIdApiRequest request)
        {
            return query.ParticipantTwoId == request.ParticipantTwoId &&
                   query.MessageId == request.MessageId &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(AddChatMessageCommandRequest command)
    {
        public bool Matches(AddChatMessageApiRequest request)
        {
            return command.ParticipantOneId == request.ParticipantOneId &&
                   command.ParticipantTwoId == request.ParticipantTwoId &&
                   command.Content == request.Body.Content;
        }
    }

    extension(UpdateChatMessageCommandRequest command)
    {
        public bool Matches(UpdateChatMessageApiRequest request)
        {
            return command.ParticipantOneId == request.ParticipantOneId &&
                   command.ParticipantTwoId == request.ParticipantTwoId &&
                   command.MessageId == request.MessageId &&
                   command.Content == request.Body.Content;
        }
    }

    extension(DeleteChatMessageCommandRequest command)
    {
        public bool Matches(DeleteChatMessageApiRequest request)
        {
            return command.ParticipantOneId == request.ParticipantOneId &&
                   command.ParticipantTwoId == request.ParticipantTwoId &&
                   command.MessageId == request.MessageId;
        }
    }

    extension(AddChatMessageApiResponse response)
    {
        public bool Matches(
        ChatMessage chatMessage,
        AddChatMessageApiRequest request)
        {
            return response.Id.Matches(chatMessage.Id);
        }
    }

    extension(UpdateChatMessageApiResponse response)
    {
        public bool Matches(
        ChatMessage chatMessage,
        UpdateChatMessageApiRequest request)
        {
            return response.Id.Matches(chatMessage.Id);
        }
    }

    extension(GetChatMessageByIdApiResponse response)
    {
        public bool Matches(ChatMessage chatMessage, GetChatMessageByIdApiRequest request)
        {
            return response.ChatMessage.MatchesFull(chatMessage, request);
        }

        public bool MatchesInverted(ChatMessage chatMessage, GetChatMessageByIdApiRequest request)
        {
            return response.ChatMessage.MatchesFullInverted(chatMessage, request);
        }
    }

    extension(GetAllChatMessagesApiResponse response)
    {
        public bool Matches(
        Chat chat,
        ICollection<ChatMessage> chatMessages,
        GetAllChatMessagesApiRequest request)
        {
            return response.ChatMessageCollection.MatchesWithoutSender(
                       (response, chatMessage) => response.MatchesWithoutChat(chatMessage, request),
                       chatMessage => chatMessage.MatchesFilter(request),
                       chat,
                       chatMessages,
                       request);
        }

        public bool Matches(
            Chat chat,
            ICollection<ChatMessage> chatMessages,
            GetAllChatMessagesApiRequest request,
            ISortEnumTermTransformer<ChatMessage> termTransformer)
        {
            return response.ChatMessageCollection.MatchesWithoutSender(
                       (response, chatMessage) => response.MatchesWithoutChat(chatMessage, request),
                       chatMessage => chatMessage.MatchesFilter(request),
                       chat,
                       chatMessages,
                       request,
                       termTransformer);
        }

        public bool MatchesInverted(Chat chat, ICollection<ChatMessage> chatMessages, GetAllChatMessagesApiRequest request)
        {
            return response.ChatMessageCollection.MatchesWithoutSenderInverted(
                (response, message) => response.MatchesWithoutChatInverted(message, request),
                message => message.MatchesFilter(request),
                chat,
                chatMessages,
                request
            );
        }

        public bool MatchesInverted(Chat chat, ICollection<ChatMessage> chatMessages, GetAllChatMessagesApiRequest request, ISortEnumTermTransformer<ChatMessage> termTransformer)
        {
            return response.ChatMessageCollection.MatchesWithoutSenderInverted(
                (response, message) => response.MatchesWithoutChatInverted(message, request),
                message => message.MatchesFilter(request),
                chat,
                chatMessages,
                request,
                termTransformer
            );
        }
    }

    extension(ChatMessage chatMessage)
    {
        public bool Matches(AddChatMessageApiRequest request)
        {
            return chatMessage.Id.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId) &&
                   chatMessage.Content == request.Body.Content;
        }

        public bool MatchesInverted(AddChatMessageApiRequest request)
        {
            return chatMessage.Id.Id.Matches(request.ParticipantTwoId, request.ParticipantOneId) &&
                   chatMessage.Content == request.Body.Content;
        }

        public bool Matches(UpdateChatMessageApiRequest request)
        {
            return chatMessage.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId, request.MessageId) &&
                   chatMessage.Content == request.Body.Content;
        }

        public bool MatchesInverted(UpdateChatMessageApiRequest request)
        {
            return chatMessage.Id.Matches(request.ParticipantTwoId, request.ParticipantOneId, request.MessageId) &&
                   chatMessage.Content == request.Body.Content;
        }

        public bool MatchesFilter(GetAllChatMessagesApiRequest request)
        {
            return (chatMessage.Id.Id.ParticipantOneId.Id.EqualsOrdinalIgnoreCase(request.CurrentUserId) &&
                   chatMessage.Id.Id.ParticipantTwoId.Id.EqualsOrdinalIgnoreCase(request.ParticipantTwoId)) ||
                   (chatMessage.Id.Id.ParticipantOneId.Id.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
                   chatMessage.Id.Id.ParticipantTwoId.Id.EqualsOrdinalIgnoreCase(request.CurrentUserId));
        }
    }

    extension(ChatMessageIdApiResponse response)
    {
        public bool Matches(ChatMessageId id)
        {
            return id.Matches(response.ParticipantOneId, response.ParticipantTwoId, response.MessageId);
        }
    }

    extension(ChatMessageApiResponse? response)
    {
        public bool MatchesFull<TRequest>(ChatMessage? chatMessage, TRequest request)
        where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   chatMessage != null &&
                   chatMessage.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId, response.MessageId) &&
                   chatMessage.SenderId.Matches(response.SenderId) &&
                   chatMessage.Content == response.Content &&
                   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
                   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
                   response.Sender.MatchesFull(chatMessage.Sender) &&
                   response.Chat.MatchesFull(chatMessage.Chat, request);
        }

        public bool MatchesWithoutSender<TRequest>(ChatMessage? chatMessage, TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   chatMessage != null &&
                   chatMessage.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId, response.MessageId) &&
                   chatMessage.SenderId.Matches(response.SenderId) &&
                   chatMessage.Content == response.Content &&
                   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
                   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
                   response.Sender == null &&
                   response.Chat.MatchesFull(chatMessage.Chat, request);
        }

        public bool MatchesWithoutChat<TRequest>(ChatMessage? chatMessage, TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   chatMessage != null &&
                   chatMessage.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId, response.MessageId) &&
                   chatMessage.SenderId.Matches(response.SenderId) &&
                   chatMessage.Content == response.Content &&
                   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
                   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
                   response.Sender.MatchesFull(chatMessage.Sender) &&
                   response.Chat == null;
        }

        public bool MatchesFullInverted<TRequest>(ChatMessage? chatMessage, TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   chatMessage != null &&
                   chatMessage.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId, response.MessageId) &&
                   chatMessage.SenderId.Matches(response.SenderId) &&
                   chatMessage.Content == response.Content &&
                   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
                   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
                   response.Sender.MatchesFull(chatMessage.Sender) &&
                   response.Chat.MatchesFullInverted(chatMessage.Chat, request);
        }

        public bool MatchesWithoutSenderInverted<TRequest>(ChatMessage? chatMessage, TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   chatMessage != null &&
                   chatMessage.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId, response.MessageId) &&
                   chatMessage.SenderId.Matches(response.SenderId) &&
                   chatMessage.Content == response.Content &&
                   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
                   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
                   response.Sender == null &&
                   response.Chat.MatchesFullInverted(chatMessage.Chat, request);
        }

        public bool MatchesWithoutChatInverted<TRequest>(ChatMessage? chatMessage, TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   chatMessage != null &&
                   chatMessage.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId, response.MessageId) &&
                   chatMessage.SenderId.Matches(response.SenderId) &&
                   chatMessage.Content == response.Content &&
                   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
                   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
                   response.Sender.MatchesFull(chatMessage.Sender) &&
                   response.Chat == null;
        }
    }

    extension(ChatMessageCollectionApiResponse response)
    {
        public bool MatchesWithoutSender<TRequest>(Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages, TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
        {
            return response.MatchesCollectionResponse(chatMessages.Count(matchesFilter), request) &&
                   response.Sender == null &&
                   response.Chat.MatchesFull(chat, request) &&
                   response.ChatMessages.MatchesCollection(
                       chatMessages,
                       response => new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId),
                       chatMessage => chatMessage.Id,
                       matches,
                       request,
                       matchesFilter
                   );
        }

        public bool MatchesWithoutSender<TRequest>(Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages, TRequest request, ISortEnumTermTransformer<ChatMessage> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
        {
            return response.MatchesCollectionResponse(chatMessages.Count(matchesFilter), request) &&
                   response.Sender == null &&
                   response.Chat.MatchesFull(chat, request) &&
                   response.ChatMessages.MatchesSortedCollection(
                       chatMessages,
                       matches,
                       termTransformer,
                       request,
                       matchesFilter
                   );
        }

        public bool MatchesWithoutChat<TRequest>(Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages, TRequest request)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
        {
            return response.MatchesCollectionResponse(chatMessages.Count(matchesFilter), request) &&
                   response.Sender.MatchesFull(user) &&
                   response.Chat == null &&
                   response.ChatMessages.MatchesCollection(
                       chatMessages,
                       response => new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId),
                       chatMessage => chatMessage.Id,
                       matches,
                       request,
                       matchesFilter
                   );
        }

        public bool MatchesWithoutChat<TRequest>(Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages, TRequest request, ISortEnumTermTransformer<ChatMessage> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
        {
            return response.MatchesCollectionResponse(chatMessages.Count(matchesFilter), request) &&
                   response.Sender.MatchesFull(user) &&
                   response.Chat == null &&
                   response.ChatMessages.MatchesSortedCollection(
                       chatMessages,
                       matches,
                       termTransformer,
                       request,
                       matchesFilter
                   );
        }
        public bool MatchesWithoutSenderInverted<TRequest>(Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages, TRequest request)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
        {
            return response.MatchesCollectionResponse(chatMessages.Count(matchesFilter), request) &&
                   response.Sender == null &&
                   response.Chat.MatchesFullInverted(chat, request) &&
                   response.ChatMessages.MatchesCollection(
                       chatMessages,
                       response => new(new(new(response.ParticipantTwoId), new(response.ParticipantOneId)), response.MessageId),
                       chatMessage => chatMessage.Id,
                       matches,
                       request,
                       matchesFilter
                   );
        }

        public bool MatchesWithoutSenderInverted<TRequest>(Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages, TRequest request, ISortEnumTermTransformer<ChatMessage> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
        {
            return response.MatchesCollectionResponse(chatMessages.Count(matchesFilter), request) &&
                   response.Sender == null &&
                   response.Chat.MatchesFullInverted(chat, request) &&
                   response.ChatMessages.MatchesSortedCollection(
                       chatMessages,
                       matches,
                       termTransformer,
                       request,
                       matchesFilter
                   );
        }

        public bool MatchesWithoutChatInverted<TRequest>(Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages, TRequest request)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
        {
            return response.MatchesCollectionResponse(chatMessages.Count(matchesFilter), request) &&
                   response.Sender.MatchesFull(user) &&
                   response.Chat == null &&
                   response.ChatMessages.MatchesCollection(
                       chatMessages,
                       response => new(new(new(response.ParticipantTwoId), new(response.ParticipantOneId)), response.MessageId),
                       chatMessage => chatMessage.Id,
                       matches,
                       request,
                       matchesFilter
                   );
        }

        public bool MatchesWithoutChatInverted<TRequest>(Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages, TRequest request, ISortEnumTermTransformer<ChatMessage> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
        {
            return response.MatchesCollectionResponse(chatMessages.Count(matchesFilter), request) &&
                   response.Sender.MatchesFull(user) &&
                   response.Chat == null &&
                   response.ChatMessages.MatchesSortedCollection(
                       chatMessages,
                       matches,
                       termTransformer,
                       request,
                       matchesFilter
                   );
        }
    }
}
