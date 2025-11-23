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
        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _chatMessageSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _chatMessageIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _chatsContext
            .ChatMessages
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id.Id.Is(filter.Id));

        var totalCountsResult = await pipeline.Count().FirstOrDefaultAsync(cancellationToken);

        var entities = await pipeline
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
        var includeProperties = _chatMessageIncludePropertyFactory.Create(include?.Properties);

        var entity = await _chatsContext
            .ChatMessages
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id.Is(id))
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
        await _chatsContext
            .ChatMessages
            .UpdateAsync(
            _chatsContext.ClientSessionHandle,
            x => x.Id.Is(entity.Id),
            entity,
            cancellationToken);
    }

    public async Task DeleteAsync(ChatMessage entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .ChatMessages
            .DeleteAsync(
            _chatsContext.ClientSessionHandle,
            x => x.Id.Is(entity.Id),
            cancellationToken);
    }
}
