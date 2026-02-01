using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Repositories;

internal class ChatMessageRepository : IChatMessageRepository
{
    private readonly IPaginator _paginator;
    private readonly IChatsContext _chatsContext;
    private readonly ISortOrdererFactory _sortOrderFactory;
    private readonly IChatMessageCollectionFactory _chatMessageCollectionFactory;
    private readonly IChatMessageSortPropertyFactory _chatMessageSortPropertyFactory;
    private readonly IChatMessageIncludePropertyFactory _chatMessageIncludePropertyFactory;

    public ChatMessageRepository(
        IPaginator paginator,
        IChatsContext chatsContext,
        ISortOrdererFactory sortOrderFactory,
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
        CommonPaginationQuery pagination,
        ChatMessageInclude include,
        CancellationToken cancellationToken)
    {
        var match = filter.GetFilter();
        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _chatMessageSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _chatMessageIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _chatsContext
            .ChatMessages
            .Aggregate()
            .Includes(includeProperties)
            .Match(match);

        var entities = await pipeline
            .Project(filter.Id.GetChatMessageProjection())
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await _chatsContext.ChatMessages.GetCount(match, cancellationToken);
        var collectionEntities = _chatMessageCollectionFactory.Create(entities, totalCount, pagination);

        return collectionEntities;
    }

    public async Task<ChatMessage?> GetByIdAsync(
        ChatMessageId id,
        ChatMessageInclude include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _chatMessageIncludePropertyFactory.Create(include?.Properties);

        var entity = await _chatsContext
            .ChatMessages
            .Aggregate()
            .Includes(includeProperties)
            .Match(id.GetFilter())
            .Project(id.Id.GetChatMessageProjection())
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

    public async Task AddRangeAsync(IEnumerable<ChatMessage> entities, CancellationToken cancellationToken)
    {
        await _chatsContext
            .ChatMessages
            .AddRangeAsync(_chatsContext.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task UpdateAsync(ChatMessage entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .ChatMessages
            .UpdateAsync(
            _chatsContext.ClientSessionHandle,
            entity.Id.GetFilter(),
            entity,
            cancellationToken);
    }

    public async Task DeleteAsync(ChatMessage entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .ChatMessages
            .DeleteAsync(
            _chatsContext.ClientSessionHandle,
            entity.Id.GetFilter(),
            cancellationToken);
    }
}
