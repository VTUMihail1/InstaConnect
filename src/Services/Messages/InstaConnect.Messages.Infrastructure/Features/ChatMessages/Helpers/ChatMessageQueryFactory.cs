using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Models;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Utilities;

namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Helpers;

public class ChatMessageQueryFactory : IChatMessageQueryFactory
{
    private readonly IPaginator _paginator;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IChatMessageSortPropertyFactory _chatMessageByParticipantSortPropertyFactory;

    public ChatMessageQueryFactory(
        IPaginator paginator,
        ISortOrderFactory sortOrderFactory,
        IChatMessageSortPropertyFactory chatMessageByParticipantSortPropertyFactory)
    {
        _paginator = paginator;
        _sortOrderFactory = sortOrderFactory;
        _chatMessageByParticipantSortPropertyFactory = chatMessageByParticipantSortPropertyFactory;
    }

    public GetAllChatMessagesQuerySpecification CreateGetAll(GetAllChatMessagesQuery query)
    {
        var sortOrder = _sortOrderFactory.Create(query.Sorting.Order);
        var sortProperty = _chatMessageByParticipantSortPropertyFactory.Create(query.Sorting.Property);
        var offset = _paginator.GetOffset(query.Pagination.Page, query.Pagination.PageSize);
        var parameters = new GetAllChatMessagesQueryParameters(
            query.Filter.ParticipantOneId,
            query.Filter.ParticipantTwoId,
            sortOrder.Order,
            sortProperty.Property,
            offset,
            query.Pagination.PageSize);

        var specification = new GetAllChatMessagesQuerySpecification(
            ChatMessageQuerySql.GetAll,
            parameters);

        return specification;
    }

    public GetAllChatMessagesTotalCountQuerySpecification CreateGetAllTotalCount(ChatMessageFilterQuery query)
    {
        var parameters = new GetAllChatMessagesTotalCountQueryParameters(
            query.ParticipantOneId,
            query.ParticipantTwoId);

        var specification = new GetAllChatMessagesTotalCountQuerySpecification(
            ChatMessageQuerySql.GetAllTotalCount,
            parameters);

        return specification;
    }

    public GetChatMessageByIdQuerySpecification CreateGetById(string participantOneId, string participantTwoId, string messageId)
    {
        var parameters = new GetChatMessageByIdQueryParameters(participantOneId, participantTwoId, messageId);

        var result = new GetChatMessageByIdQuerySpecification(
            ChatMessageQuerySql.GetById,
            parameters);

        return result;
    }
}
