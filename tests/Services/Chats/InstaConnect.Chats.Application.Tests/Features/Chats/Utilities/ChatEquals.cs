using InstaConnect.Chats.Application.Features.Chats.Models;
using InstaConnect.Chats.Application.Features.Users.Abstractions;
using InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Application.Tests.Features.Users.Utilities;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;

public static class ChatEquals
{
    extension(GetAllChatsQuery query)
    {
        public bool Matches(GetAllChatsQueryRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllChatsQuery, ChatsSortTerm, ChatsSortingQuery, GetAllChatsQueryRequest>(request) &&
                   query.MatchesPaginatable<GetAllChatsQuery, ChatsPaginationQuery, GetAllChatsQueryRequest>(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllChatsQueryRequest request)
        {
            return query.Filter.ParticipantOneId.Matches(request.CurrentUserId) &&
                   query.Filter.ParticipantTwoName.Matches(request.ParticipantTwoName);
        }
    }

    extension(GetChatByIdQuery query)
    {
        public bool Matches(GetChatByIdQueryRequest request)
        {
            return query.Id.Matches(request.CurrentUserId, request.ParticipantTwoId) &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(AddChatCommand command)
    {
        public bool Matches(AddChatCommandRequest request)
        {
            return command.ParticipantOneId.Matches(request.ParticipantOneId) &&
                   command.ParticipantTwoId.Matches(request.ParticipantTwoId);
        }
    }

    extension(AddChatCommandResponse response)
    {
        public bool Matches(Chat chat, AddChatCommandRequest request)
        {
            return response.Id.Matches(chat.Id);
        }
    }

    extension(GetChatByIdQueryResponse response)
    {
        public bool Matches(Chat chat, GetChatByIdQueryRequest request)
        {
            return response.Chat.MatchesFull(chat, request);
        }

        public bool MatchesInverted(Chat chat, GetChatByIdQueryRequest request)
        {
            return response.Chat.MatchesFullInverted(chat, request);
        }
    }

    extension(GetAllChatsQueryResponse response)
    {
        public bool Matches(
            User participantOne,
            ICollection<Chat> chats,
            GetAllChatsQueryRequest request)
        {
            return response.ChatCollection.MatchesWithoutParticipantTwo(
                       (response, chat) => response.MatchesWithoutParticipantOne(chat, request),
                       chat => chat.MatchesFilter(request),
                       participantOne,
                       chats,
                       request);
        }

        public bool Matches(
            User participantOne,
            ICollection<Chat> chats,
            GetAllChatsQueryRequest request,
            ISortEnumTermTransformer<Chat> termTransformer)
        {
            return response.ChatCollection.MatchesWithoutParticipantTwo(
                       (response, chat) => response.MatchesWithoutParticipantOne(chat, request),
                       chat => chat.MatchesFilter(request),
                       participantOne,
                       chats,
                       request,
                       termTransformer);
        }

        public bool MatchesInverted(
            User participantTwo,
            ICollection<Chat> chats,
            GetAllChatsQueryRequest request)
        {
            return response.ChatCollection.MatchesWithoutParticipantTwoInverted(
                       (response, chat) => response.MatchesWithoutParticipantOneInverted(chat, request),
                       chat => chat.MatchesFilter(request),
                       participantTwo,
                       chats,
                       request);
        }

        public bool MatchesInverted(
            User participantTwo,
            ICollection<Chat> chats,
            GetAllChatsQueryRequest request,
            ISortEnumTermTransformer<Chat> termTransformer)
        {
            return response.ChatCollection.MatchesWithoutParticipantTwoInverted(
                       (response, chat) => response.MatchesWithoutParticipantOneInverted(chat, request),
                       chat => chat.MatchesFilter(request),
                       participantTwo,
                       chats,
                       request,
                       termTransformer);
        }
    }

    extension(Chat chat)
    {
        public bool Matches(AddChatCommandRequest request)
        {
            return chat.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId);
        }

        public bool MatchesFilter(GetAllChatsQueryRequest request)
        {
            return (chat.Id.ParticipantOneId.Matches(request.CurrentUserId) &&
                   chat.ParticipantTwo != null &&
                   chat.ParticipantTwo.Name.Value.StartsWithOrdinalIgnoreCase(request.ParticipantTwoName)) ||
                   (chat.Id.ParticipantTwoId.Matches(request.CurrentUserId) &&
                   chat.ParticipantOne != null &&
                   chat.ParticipantOne.Name.Value.StartsWithOrdinalIgnoreCase(request.ParticipantTwoName));
        }
    }

    extension(ChatIdCommandResponse response)
    {
        public bool Matches(ChatId id)
        {
            return id.Matches(response.ParticipantOneId, response.ParticipantTwoId);
        }
    }

    extension(ChatQueryResponse? response)
    {
        public bool MatchesFull<TRequest>(Chat? chat, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   chat != null &&
                   chat.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId) &&
                   chat.CreatedAtUtc == response.CreatedAtUtc &&
                   response.ParticipantOne.MatchesFull(chat.ParticipantOne) &&
                   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
        }

        public bool MatchesWithoutParticipantOne<TRequest>(Chat? chat, TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   chat != null &&
                   chat.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId) &&
                   chat.CreatedAtUtc == response.CreatedAtUtc &&
                   response.ParticipantOne == null &&
                   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
        }

        public bool MatchesWithoutParticipantTwo<TRequest>(Chat? chat, TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   chat != null &&
                   chat.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId) &&
                   chat.CreatedAtUtc == response.CreatedAtUtc &&
                   response.ParticipantOne.MatchesFull(chat.ParticipantOne) &&
                   response.ParticipantTwo == null;
        }

        public bool MatchesFullInverted<TRequest>(Chat? chat, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   chat != null &&
                   chat.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId) &&
                   chat.CreatedAtUtc == response.CreatedAtUtc &&
                   response.ParticipantOne.MatchesFull(chat.ParticipantTwo) &&
                   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
        }

        public bool MatchesWithoutParticipantOneInverted<TRequest>(Chat? chat, TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   chat != null &&
                   chat.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId) &&
                   chat.CreatedAtUtc == response.CreatedAtUtc &&
                   response.ParticipantOne == null &&
                   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
        }

        public bool MatchesWithoutParticipantTwoInverted<TRequest>(Chat? chat, TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   chat != null &&
                   chat.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId) &&
                   chat.CreatedAtUtc == response.CreatedAtUtc &&
                   response.ParticipantOne.MatchesFull(chat.ParticipantTwo) &&
                   response.ParticipantTwo == null;
        }
    }

    extension(ChatCollectionQueryResponse response)
    {
        public bool MatchesWithoutParticipantOne<TRequest>(
            Func<ChatQueryResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantTwo,
            ICollection<Chat> chats,
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(chats.Count(matchesFilter), request) &&
                   response.ParticipantOne == null &&
                   response.ParticipantTwo.MatchesFull(participantTwo) &&
                   response.Chats.MatchesCollection(chats,
                                                    response => new(new(response.ParticipantOneId), new(response.ParticipantTwoId)),
                                                    chat => chat.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
        }

        public bool MatchesWithoutParticipantOne<TRequest>(
            Func<ChatQueryResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantTwo,
            ICollection<Chat> chats,
            TRequest request,
            ISortEnumTermTransformer<Chat> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(chats.Count(matchesFilter), request) &&
                   response.ParticipantOne == null &&
                   response.ParticipantTwo.MatchesFull(participantTwo) &&
                   response.Chats.MatchesSortedCollection(chats,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
        }

        public bool MatchesWithoutParticipantTwo<TRequest>(
            Func<ChatQueryResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantOne,
            ICollection<Chat> chats,
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(chats.Count(matchesFilter), request) &&
                   response.ParticipantOne.MatchesFull(participantOne) &&
                   response.ParticipantTwo == null &&
                   response.Chats.MatchesCollection(chats,
                                                    response => new(new(response.ParticipantOneId), new(response.ParticipantTwoId)),
                                                    chat => chat.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
        }

        public bool MatchesWithoutParticipantTwo<TRequest>(
            Func<ChatQueryResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantOne,
            ICollection<Chat> chats,
            TRequest request,
            ISortEnumTermTransformer<Chat> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(chats.Count(matchesFilter), request) &&
                   response.ParticipantOne.MatchesFull(participantOne) &&
                   response.ParticipantTwo == null &&
                   response.Chats.MatchesSortedCollection(chats,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
        }

        public bool MatchesWithoutParticipantOneInverted<TRequest>(
            Func<ChatQueryResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantTwo,
            ICollection<Chat> chats,
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(chats.Count(matchesFilter), request) &&
                   response.ParticipantOne == null &&
                   response.ParticipantTwo.MatchesFull(participantTwo) &&
                   response.Chats.MatchesCollection(chats,
                                                    response => new(new(response.ParticipantTwoId), new(response.ParticipantOneId)),
                                                    chat => chat.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
        }

        public bool MatchesWithoutParticipantOneInverted<TRequest>(
            Func<ChatQueryResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantTwo,
            ICollection<Chat> chats,
            TRequest request,
            ISortEnumTermTransformer<Chat> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(chats.Count(matchesFilter), request) &&
                   response.ParticipantOne == null &&
                   response.ParticipantTwo.MatchesFull(participantTwo) &&
                   response.Chats.MatchesSortedCollection(chats,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
        }

        public bool MatchesWithoutParticipantTwoInverted<TRequest>(
            Func<ChatQueryResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantOne,
            ICollection<Chat> chats,
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(chats.Count(matchesFilter), request) &&
                   response.ParticipantOne.MatchesFull(participantOne) &&
                   response.ParticipantTwo == null &&
                   response.Chats.MatchesCollection(chats,
                                                    response => new(new(response.ParticipantTwoId), new(response.ParticipantOneId)),
                                                    chat => chat.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
        }

        public bool MatchesWithoutParticipantTwoInverted<TRequest>(
            Func<ChatQueryResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantOne,
            ICollection<Chat> chats,
            TRequest request,
            ISortEnumTermTransformer<Chat> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(chats.Count(matchesFilter), request) &&
                   response.ParticipantOne.MatchesFull(participantOne) &&
                   response.ParticipantTwo == null &&
                   response.Chats.MatchesSortedCollection(chats,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
        }
    }
}
