using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;

using MongoDB.Driver;

namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Repositories;

internal class ChatMessageRepository : IChatMessageRepository
{
    private readonly IPaginator _paginator;
    private readonly IChatsContext _chatsContext;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IChatMessageCollectionFactory _chatMessageCollectionFactory;
    private readonly IChatMessageSortPropertyFactory _chatMessageSortPropertyFactory;
    private readonly IChatMessageIncludePropertyFactory _chatMessageIncludePropertyFactory;

    public ChatMessageRepository(
        IPaginator paginator,
        IChatsContext chatsContext,
        ISortOrderFactory sortOrderFactory,
        IChatMessageCollectionFactory chatMessageCollectionFactory,
        IChatMessageSortPropertyFactory chatMessageSortPropertyFactory,
        IChatMessageIncludePropertyFactory chatMessageIncludePropertyFactory)
    {
        _paginator = paginator;
        _chatsContext = chatsContext;
        _sortOrderFactory = sortOrderFactory;
        _chatMessageCollectionFactory = chatMessageCollectionFactory;
        _chatMessageSortPropertyFactory = chatMessageSortPropertyFactory;
        _chatMessageIncludePropertyFactory = chatMessageIncludePropertyFactory;
    }

    public async Task<ChatMessageCollection> GetAllAsync(
        ChatMessageFilterQuery filter,
        ChatMessageSortingQuery sorting,
        ChatMessagePaginationQuery pagination,
        ChatMessageIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _chatMessageSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _chatMessageIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _chatsContext
            .ChatMessages
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => (p.ParticipantOneId == filter.ParticipantOneId ||
                         p.ParticipantTwoId == filter.ParticipantOneId) &&
                        (p.ParticipantOneId == filter.ParticipantTwoId ||
                         p.ParticipantTwoId == filter.ParticipantTwoId));

        var totalCountsResult = await pipeline.Count().FirstOrDefaultAsync(cancellationToken);

        var entities = await pipeline
            .Project(a => new ChatMessage(
                a.ParticipantOneId == filter.ParticipantOneId ? a.ParticipantOneId! : a.ParticipantTwoId!,
                a.ParticipantTwoId == filter.ParticipantOneId ? a.ParticipantTwoId! : a.ParticipantOneId!,
                a.MessageId,
                a.Sender!,
                a.Content,
                a.CreatedAt,
                a.UpdatedAt))
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var collectionEntities = _chatMessageCollectionFactory.Create(entities, (int)totalCountsResult.Count, pagination);

        return collectionEntities;
    }

    public async Task<ChatMessage?> GetByIdAsync(
        string participantOneId,
        string participantTwoId,
        string messageId,
        ChatMessageIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _chatMessageIncludePropertyFactory.Create(include?.Properties);

        var entity = await _chatsContext
            .ChatMessages
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.ParticipantOneId == participantOneId &&
                        p.ParticipantTwoId == participantTwoId &&
                        p.MessageId == messageId)
            .Project(a => new ChatMessage(
                a.ParticipantOneId == participantOneId ? a.ParticipantOneId! : a.ParticipantTwoId!,
                a.ParticipantTwoId == participantOneId ? a.ParticipantTwoId! : a.ParticipantOneId!,
                a.MessageId,
                a.Sender!,
                a.Content,
                a.CreatedAt,
                a.UpdatedAt))
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<ChatMessage?> GetByIdAsync(
        string participantOneId,
        string participantTwoId,
        string messageId,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(participantOneId, participantTwoId, messageId, null, cancellationToken);
    }

    public async Task AddAsync(ChatMessage entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .ChatMessages
            .AddAsync(_chatsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task UpdateAsync(ChatMessage entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .ChatMessages
            .UpdateAsync(
            _chatsContext.ClientSessionHandle,
            x => x.ParticipantOneId == entity.ParticipantOneId &&
                 x.ParticipantTwoId == entity.ParticipantTwoId &&
                 x.MessageId == entity.MessageId,
            entity,
            cancellationToken);
    }

    public async Task DeleteAsync(ChatMessage entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .ChatMessages
            .DeleteAsync(
            _chatsContext.ClientSessionHandle,
            x => x.ParticipantOneId == entity.ParticipantOneId &&
                 x.ParticipantTwoId == entity.ParticipantTwoId &&
                 x.MessageId == entity.MessageId,
            cancellationToken);
    }
}
