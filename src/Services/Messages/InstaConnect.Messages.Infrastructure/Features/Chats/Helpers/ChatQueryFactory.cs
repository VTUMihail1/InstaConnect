using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Models;
using InstaConnect.Chats.Infrastructure.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers;

public class ChatQueryFactory : IChatQueryFactory
{
    private readonly IPaginator _paginator;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IChatByParticipantSortPropertyFactory _chatByParticipantSortPropertyFactory;

    public ChatQueryFactory(
        IPaginator paginator,
        ISortOrderFactory sortOrderFactory,
        IChatByParticipantSortPropertyFactory chatByParticipantSortPropertyFactory)
    {
        _paginator = paginator;
        _sortOrderFactory = sortOrderFactory;
        _chatByParticipantSortPropertyFactory = chatByParticipantSortPropertyFactory;
    }

    public GetAllChatsByParticipantQuerySpecification CreateGetAllByParticipant(GetAllChatsByParticipantQuery query)
    {
        var sortOrder = _sortOrderFactory.Create(query.Sorting.Order);
        var sortProperty = _chatByParticipantSortPropertyFactory.Create(query.Sorting.Property);
        var offset = _paginator.GetOffset(query.Pagination.Page, query.Pagination.PageSize);
        var parameters = new GetAllChatsByParticipantQueryParameters(
            query.Filter.ParticipantId,
            query.Filter.ParticipantName,
            sortOrder.Order,
            sortProperty.Property,
            offset,
            query.Pagination.PageSize);

        var specification = new GetAllChatsByParticipantQuerySpecification(
            ChatQuerySql.GetAllByParticipant,
            parameters);

        return specification;
    }

    public GetAllChatsByParticipantTotalCountQuerySpecification CreateGetAllByParticipantTotalCount(ChatByParticipantFilterQuery query)
    {
        var parameters = new GetAllChatsByParticipantTotalCountQueryParameters(
            query.ParticipantId,
            query.ParticipantName);

        var specification = new GetAllChatsByParticipantTotalCountQuerySpecification(
            ChatQuerySql.GetAllByParticipantTotalCount,
            parameters);

        return specification;
    }

    public GetChatByIdQuerySpecification CreateGetById(string participantOneId, string participantTwoId)
    {
        var parameters = new GetChatByIdQueryParameters(participantOneId, participantTwoId);

        var result = new GetChatByIdQuerySpecification(
            ChatQuerySql.GetById,
            parameters);

        return result;
    }
}
