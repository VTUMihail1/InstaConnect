using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Repositories;

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
        var match = Builders<ChatMessage>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id.ParticipantOneId.Id, filter.Id.ParticipantOneId.Id)
            .OrEqualsCaseInsensitive(p => p.Id.Id.ParticipantTwoId.Id, filter.Id.ParticipantOneId.Id)
            .AndEqualsCaseInsensitive(p => p.Id.Id.ParticipantOneId.Id, filter.Id.ParticipantTwoId.Id)
            .OrEqualsCaseInsensitive(p => p.Id.Id.ParticipantTwoId.Id, filter.Id.ParticipantTwoId.Id);

        var projection = Builders<ChatMessage>.Projection.Expression(
            c => new ChatMessage(c.Id.Id.ParticipantOneId.Id.ToLower() == filter.Id.ParticipantOneId.Id.ToLower()
                                  ? c.Id : new(
                                               new(
                                                   c.Id.Id.ParticipantTwoId,
                                                   c.Id.Id.ParticipantOneId),
                                               c.Id.MessageId),
                                    c.SenderId,
                                    c.Content,
                                    c.CreatedAtUtc,
                                    c.UpdatedAtUtc));


        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _chatMessageSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _chatMessageIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _chatsContext
            .ChatMessages
            .Aggregate()
            .Includes(includeProperties)
            .Match(match);

        var totalCountsResult = await pipeline.Count().FirstOrDefaultAsync(cancellationToken);

        var entities = await pipeline
            .Project(projection)
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var collectionEntities = _chatMessageCollectionFactory.Create(entities, (int)totalCountsResult.Count, pagination);

        return collectionEntities;
    }

    public async Task<ChatMessage?> GetByIdAsync(
        ChatMessageId id,
        ChatMessageIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var match = Builders<ChatMessage>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id.ParticipantOneId.Id, id.Id.ParticipantOneId.Id)
            .OrEqualsCaseInsensitive(p => p.Id.Id.ParticipantTwoId.Id, id.Id.ParticipantOneId.Id)
            .AndEqualsCaseInsensitive(p => p.Id.Id.ParticipantOneId.Id, id.Id.ParticipantTwoId.Id)
            .OrEqualsCaseInsensitive(p => p.Id.Id.ParticipantTwoId.Id, id.Id.ParticipantTwoId.Id)
            .AndEqualsCaseInsensitive(p => p.Id.MessageId, id.MessageId);

        var projection = Builders<ChatMessage>.Projection.Expression(
            c => new ChatMessage(c.Id.Id.ParticipantOneId.Id.ToLower() == id.Id.ParticipantOneId.Id.ToLower()
                                  ? c.Id : new(
                                               new(
                                                   c.Id.Id.ParticipantTwoId,
                                                   c.Id.Id.ParticipantOneId),
                                               c.Id.MessageId),
                                    c.SenderId,
                                    c.Content,
                                    c.CreatedAtUtc,
                                    c.UpdatedAtUtc));

        var includeProperties = _chatMessageIncludePropertyFactory.Create(include?.Properties);

        var entity = await _chatsContext
            .ChatMessages
            .Aggregate()
            .Includes(includeProperties)
            .Match(match)
            .Project(projection)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<ChatMessage?> GetByIdAsync(
        ChatMessageId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task AddAsync(ChatMessage entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .ChatMessages
            .AddAsync(_chatsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task UpdateAsync(ChatMessage entity, CancellationToken cancellationToken)
    {
        var match = Builders<ChatMessage>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id.ParticipantOneId.Id, entity.Id.Id.ParticipantOneId.Id)
            .OrEqualsCaseInsensitive(p => p.Id.Id.ParticipantTwoId.Id, entity.Id.Id.ParticipantOneId.Id)
            .AndEqualsCaseInsensitive(p => p.Id.Id.ParticipantOneId.Id, entity.Id.Id.ParticipantTwoId.Id)
            .OrEqualsCaseInsensitive(p => p.Id.Id.ParticipantTwoId.Id, entity.Id.Id.ParticipantTwoId.Id)
            .AndEqualsCaseInsensitive(p => p.Id.MessageId, entity.Id.MessageId);

        await _chatsContext
            .ChatMessages
            .UpdateAsync(
            _chatsContext.ClientSessionHandle,
            match,
            entity,
            cancellationToken);
    }

    public async Task DeleteAsync(ChatMessage entity, CancellationToken cancellationToken)
    {
        var match = Builders<ChatMessage>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id.ParticipantOneId.Id, entity.Id.Id.ParticipantOneId.Id)
            .OrEqualsCaseInsensitive(p => p.Id.Id.ParticipantTwoId.Id, entity.Id.Id.ParticipantOneId.Id)
            .AndEqualsCaseInsensitive(p => p.Id.Id.ParticipantOneId.Id, entity.Id.Id.ParticipantTwoId.Id)
            .OrEqualsCaseInsensitive(p => p.Id.Id.ParticipantTwoId.Id, entity.Id.Id.ParticipantTwoId.Id)
            .AndEqualsCaseInsensitive(p => p.Id.MessageId, entity.Id.MessageId);

        await _chatsContext
            .ChatMessages
            .DeleteAsync(
            _chatsContext.ClientSessionHandle,
            match,
            cancellationToken);
    }
}
