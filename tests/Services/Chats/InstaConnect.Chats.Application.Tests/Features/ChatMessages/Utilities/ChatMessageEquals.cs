using InstaConnect.Chats.Application.Features.ChatMessages.Models;
using InstaConnect.Chats.Application.Features.Users.Abstractions;
using InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Application.Tests.Features.Users.Utilities;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageEquals
{
    extension(GetAllChatMessagesQuery query)
    {
        public bool Matches(GetAllChatMessagesQueryRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllChatMessagesQuery, ChatMessagesSortTerm, ChatMessagesSortingQuery, GetAllChatMessagesQueryRequest>(request) &&
                   query.MatchesPaginatable<GetAllChatMessagesQuery, ChatMessagesPaginationQuery, GetAllChatMessagesQueryRequest>(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllChatMessagesQueryRequest request)
        {
            return query.Filter.Id.Matches(request.CurrentUserId, request.ParticipantTwoId);
        }
    }

    extension(GetChatMessageByIdQuery query)
    {
        public bool Matches(GetChatMessageByIdQueryRequest request)
        {
            return query.Id.Matches(request.CurrentUserId, request.ParticipantTwoId, request.MessageId) &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(AddChatMessageCommand command)
    {
        public bool Matches(AddChatMessageCommandRequest request)
        {
            return command.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId) &&
                   command.Content == request.Content;
        }
    }

    extension(UpdateChatMessageCommand command)
    {
        public bool Matches(UpdateChatMessageCommandRequest request)
        {
            return command.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId, request.MessageId) &&
                   command.Content == request.Content;
        }
    }

    extension(DeleteChatMessageCommand command)
    {
        public bool Matches(DeleteChatMessageCommandRequest request)
        {
            return command.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId, request.MessageId);
        }
    }

    extension(AddChatMessageCommandResponse response)
    {
        public bool Matches(ChatMessage chatMessage, AddChatMessageCommandRequest request)
        {
            return response.Id.Matches(chatMessage.Id);
        }
    }

    extension(UpdateChatMessageCommandResponse response)
    {
        public bool Matches(ChatMessage chatMessage, UpdateChatMessageCommandRequest request)
        {
            return response.Id.Matches(chatMessage.Id);
        }
    }

    extension(GetChatMessageByIdQueryResponse response)
    {
        public bool Matches(ChatMessage chatMessage, GetChatMessageByIdQueryRequest request)
        {
            return response.ChatMessage.MatchesFull(chatMessage, request);
        }

        public bool MatchesInverted(ChatMessage chatMessage, GetChatMessageByIdQueryRequest request)
        {
            return response.ChatMessage.MatchesFullInverted(chatMessage, request);
        }
    }

    extension(GetAllChatMessagesQueryResponse response)
    {
        public bool Matches(Chat chat, ICollection<ChatMessage> chatMessages, GetAllChatMessagesQueryRequest request)
        {
            return response.ChatMessageCollection.MatchesWithoutSender(
                (response, message) => response.MatchesWithoutChat(message, request),
                message => message.MatchesFilter(request),
                chat,
                chatMessages,
                request
            );
        }

        public bool Matches(Chat chat, ICollection<ChatMessage> chatMessages, GetAllChatMessagesQueryRequest request, ISortEnumTermTransformer<ChatMessage> termTransformer)
        {
            return response.ChatMessageCollection.MatchesWithoutSender(
                (response, message) => response.MatchesWithoutChat(message, request),
                message => message.MatchesFilter(request),
                chat,
                chatMessages,
                request,
                termTransformer
            );
        }

        public bool MatchesInverted(Chat chat, ICollection<ChatMessage> chatMessages, GetAllChatMessagesQueryRequest request)
        {
            return response.ChatMessageCollection.MatchesWithoutSenderInverted(
                (response, message) => response.MatchesWithoutChatInverted(message, request),
                message => message.MatchesFilter(request),
                chat,
                chatMessages,
                request
            );
        }

        public bool MatchesInverted(Chat chat, ICollection<ChatMessage> chatMessages, GetAllChatMessagesQueryRequest request, ISortEnumTermTransformer<ChatMessage> termTransformer)
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
        public bool Matches(AddChatMessageCommandRequest request)
        {
            return chatMessage.Id.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId) &&
                   chatMessage.Content == request.Content;
        }

        public bool MatchesInverted(AddChatMessageCommandRequest request)
        {
            return chatMessage.Id.Id.Matches(request.ParticipantTwoId, request.ParticipantOneId) &&
                   chatMessage.Content == request.Content;
        }

        public bool Matches(UpdateChatMessageCommandRequest request)
        {
            return chatMessage.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId, request.MessageId) &&
                   chatMessage.Content == request.Content;
        }

        public bool MatchesInverted(UpdateChatMessageCommandRequest request)
        {
            return chatMessage.Id.Matches(request.ParticipantTwoId, request.ParticipantOneId, request.MessageId) &&
                   chatMessage.Content == request.Content;
        }

        public bool MatchesFilter(GetAllChatMessagesQueryRequest request)
        {
            return (chatMessage.Id.Id.ParticipantOneId.Id.EqualsOrdinalIgnoreCase(request.CurrentUserId) &&
                   chatMessage.Id.Id.ParticipantTwoId.Id.EqualsOrdinalIgnoreCase(request.ParticipantTwoId)) ||
                   (chatMessage.Id.Id.ParticipantOneId.Id.EqualsOrdinalIgnoreCase(request.ParticipantTwoId) &&
                   chatMessage.Id.Id.ParticipantTwoId.Id.EqualsOrdinalIgnoreCase(request.CurrentUserId));
        }
    }

    extension(ChatMessageIdCommandResponse response)
    {
        public bool Matches(ChatMessageId id)
        {
            return id.Matches(response.ParticipantOneId, response.ParticipantTwoId, response.MessageId);
        }
    }

    extension(ChatMessageQueryResponse? response)
    {
        public bool MatchesFull<TRequest>(ChatMessage? chatMessage, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
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
            where TRequest : ICurrentUserableQueryRequest
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
            where TRequest : ICurrentUserableQueryRequest
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
        where TRequest : ICurrentUserableQueryRequest
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
            where TRequest : ICurrentUserableQueryRequest
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
            where TRequest : ICurrentUserableQueryRequest
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

    extension(ChatMessageCollectionQueryResponse response)
    {
        public bool MatchesWithoutSender<TRequest>(Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages, TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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

        public bool MatchesWithoutSender<TRequest>(Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages, TRequest request, ISortEnumTermTransformer<ChatMessage> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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

        public bool MatchesWithoutChat<TRequest>(Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages, TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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

        public bool MatchesWithoutChat<TRequest>(Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages, TRequest request, ISortEnumTermTransformer<ChatMessage> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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
        public bool MatchesWithoutSenderInverted<TRequest>(Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages, TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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

        public bool MatchesWithoutSenderInverted<TRequest>(Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages, TRequest request, ISortEnumTermTransformer<ChatMessage> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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

        public bool MatchesWithoutChatInverted<TRequest>(Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages, TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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

        public bool MatchesWithoutChatInverted<TRequest>(Func<ChatMessageQueryResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages, TRequest request, ISortEnumTermTransformer<ChatMessage> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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
