using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Presentation.Features.Users.Abstractions;
using InstaConnect.Chats.Presentation.Tests.Features.Users.Utilities;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

public static class ChatEquals
{
    extension(GetAllChatsQueryRequest query)
    {
        public bool Matches(GetAllChatsApiRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllChatsQueryRequest, ChatsSortTerm, GetAllChatsApiRequest>(request) &&
                   query.MatchesPaginatable(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllChatsApiRequest request)
        {
            return query.ParticipantTwoName == request.ParticipantTwoName;
        }
    }

    extension(GetChatByIdQueryRequest query)
    {
        public bool Matches(GetChatByIdApiRequest request)
        {
            return query.ParticipantTwoId == request.ParticipantTwoId &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(AddChatCommandRequest command)
    {
        public bool Matches(AddChatApiRequest request)
        {
            return command.ParticipantOneId == request.ParticipantOneId &&
                   command.ParticipantTwoId == request.Body.ParticipantTwoId;
        }
    }

    extension(AddChatApiResponse response)
    {
        public bool Matches(
        Chat chat,
        AddChatApiRequest request)
        {
            return response.Response.Matches(chat.Id);
        }
    }

    extension(GetChatByIdApiResponse response)
    {
        public bool Matches(Chat chat, GetChatByIdApiRequest request)
        {
            return response.Response.MatchesFull(chat, request);
        }

        public bool MatchesInverted(Chat chat, GetChatByIdApiRequest request)
        {
            return response.Response.MatchesFullInverted(chat, request);
        }
    }

    extension(GetAllChatsApiResponse response)
    {
        public bool Matches(
        User participantOne,
        ICollection<Chat> chats,
        GetAllChatsApiRequest request)
        {
            return response.Response.MatchesWithoutParticipantTwo(
                       (response, chat) => response.MatchesWithoutParticipantOne(chat, request),
                       chat => chat.MatchesFilter(request),
                       participantOne,
                       chats,
                       request);
        }

        public bool Matches(
            User participantOne,
            ICollection<Chat> chats,
            GetAllChatsApiRequest request,
            ISortEnumTermTransformer<Chat> termTransformer)
        {
            return response.Response.MatchesWithoutParticipantTwo(
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
        GetAllChatsApiRequest request)
        {
            return response.Response.MatchesWithoutParticipantTwoInverted(
                       (response, chat) => response.MatchesWithoutParticipantOneInverted(chat, request),
                       chat => chat.MatchesFilter(request),
                       participantTwo,
                       chats,
                       request);
        }

        public bool MatchesInverted(
            User participantTwo,
            ICollection<Chat> chats,
            GetAllChatsApiRequest request,
            ISortEnumTermTransformer<Chat> termTransformer)
        {
            return response.Response.MatchesWithoutParticipantTwoInverted(
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
        public bool Matches(AddChatApiRequest request)
        {
            return chat.Id.Matches(request.ParticipantOneId, request.Body.ParticipantTwoId);
        }

        public bool MatchesFilter(GetAllChatsApiRequest request)
        {
            return (chat.Id.ParticipantOneId.Matches(request.CurrentUserId) &&
                   chat.ParticipantTwo != null &&
                   chat.ParticipantTwo.Name.Value.StartsWithOrdinalIgnoreCase(request.ParticipantTwoName)) ||
                   (chat.Id.ParticipantTwoId.Matches(request.CurrentUserId) &&
                   chat.ParticipantOne != null &&
                   chat.ParticipantOne.Name.Value.StartsWithOrdinalIgnoreCase(request.ParticipantTwoName));
        }
    }

    extension(ChatIdApiResponse response)
    {
        public bool Matches(ChatId id)
        {
            return id.Matches(response.ParticipantOneId, response.ParticipantTwoId);
        }
    }

    extension(ChatApiResponse? response)
    {
        public bool MatchesFull<TRequest>(Chat? chat, TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   chat != null &&
                   chat.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId) &&
                   chat.CreatedAtUtc == response.CreatedAtUtc &&
                   response.ParticipantOne.MatchesFull(chat.ParticipantOne) &&
                   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
        }

        public bool MatchesWithoutParticipantOne<TRequest>(Chat? chat, TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   chat != null &&
                   chat.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId) &&
                   chat.CreatedAtUtc == response.CreatedAtUtc &&
                   response.ParticipantOne == null &&
                   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
        }

        public bool MatchesWithoutParticipantTwo<TRequest>(Chat? chat, TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   chat != null &&
                   chat.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId) &&
                   chat.CreatedAtUtc == response.CreatedAtUtc &&
                   response.ParticipantOne.MatchesFull(chat.ParticipantOne) &&
                   response.ParticipantTwo == null;
        }

        public bool MatchesFullInverted<TRequest>(Chat? chat, TRequest request)
        where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   chat != null &&
                   chat.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId) &&
                   chat.CreatedAtUtc == response.CreatedAtUtc &&
                   response.ParticipantOne.MatchesFull(chat.ParticipantTwo) &&
                   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
        }

        public bool MatchesWithoutParticipantOneInverted<TRequest>(Chat? chat, TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   chat != null &&
                   chat.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId) &&
                   chat.CreatedAtUtc == response.CreatedAtUtc &&
                   response.ParticipantOne == null &&
                   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
        }

        public bool MatchesWithoutParticipantTwoInverted<TRequest>(Chat? chat, TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   chat != null &&
                   chat.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId) &&
                   chat.CreatedAtUtc == response.CreatedAtUtc &&
                   response.ParticipantOne.MatchesFull(chat.ParticipantTwo) &&
                   response.ParticipantTwo == null;
        }
    }

    extension(ChatCollectionApiResponse response)
    {
        public bool MatchesWithoutParticipantOne<TRequest>(
            Func<ChatApiResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantTwo,
            ICollection<Chat> chats,
            TRequest request)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<ChatApiResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantTwo,
            ICollection<Chat> chats,
            TRequest request,
            ISortEnumTermTransformer<Chat> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<ChatApiResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantOne,
            ICollection<Chat> chats,
            TRequest request)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<ChatApiResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantOne,
            ICollection<Chat> chats,
            TRequest request,
            ISortEnumTermTransformer<Chat> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<ChatApiResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantTwo,
            ICollection<Chat> chats,
            TRequest request)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<ChatApiResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantTwo,
            ICollection<Chat> chats,
            TRequest request,
            ISortEnumTermTransformer<Chat> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<ChatApiResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantOne,
            ICollection<Chat> chats,
            TRequest request)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<ChatApiResponse, Chat, bool> matches,
            Func<Chat, bool> matchesFilter,
            User participantOne,
            ICollection<Chat> chats,
            TRequest request,
            ISortEnumTermTransformer<Chat> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
