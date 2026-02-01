using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Repositories;

internal class ChatRepository : IChatRepository
{
    private readonly IPaginator _paginator;
    private readonly IChatsContext _chatsContext;
    private readonly ISortOrdererFactory _sortOrderFactory;
    private readonly IChatCollectionFactory _chatCollectionFactory;
    private readonly IChatIncludePropertyFactory _chatIncludePropertyFactory;
    private readonly IChatByParticipantSortPropertyFactory _chatSortPropertyFactory;

    public ChatRepository(
        IPaginator paginator,
        IChatsContext chatsContext,
        ISortOrdererFactory sortOrderFactory,
        IChatCollectionFactory chatCollectionFactory,
        IChatIncludePropertyFactory chatIncludePropertyFactory,
        IChatByParticipantSortPropertyFactory chatSortPropertyFactory)
    {
        _paginator = paginator;
        _chatsContext = chatsContext;
        _sortOrderFactory = sortOrderFactory;
        _chatCollectionFactory = chatCollectionFactory;
        _chatSortPropertyFactory = chatSortPropertyFactory;
        _chatIncludePropertyFactory = chatIncludePropertyFactory;
    }

    public async Task<ChatCollection> GetAllByParticipantAsync(
        ChatByParticipantFilterQuery filter,
        CommonSortingQuery<ChatByParticipantSortProperty> sorting,
        CommonPaginationQuery pagination,
        ChatInclude include,
        CancellationToken cancellationToken)
    {
        var match = filter.GetFilter();

        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _chatSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _chatIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _chatsContext
            .Chats
            .Aggregate()
            .Includes(includeProperties)
            .Match(match);

        var entities = await pipeline
            .Project(filter.ParticipantId.GetChatProjection())
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await _chatsContext.Chats.GetCount(match, cancellationToken);
        var collectionEntities = _chatCollectionFactory.Create(entities, totalCount, pagination);

        return collectionEntities;
    }

    public async Task<Chat?> GetByIdAsync(
        ChatId id,
        ChatInclude include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _chatIncludePropertyFactory.Create(include?.Properties);

        var entity = await _chatsContext
            .Chats
            .Aggregate()
            .Includes(includeProperties)
            .Match(id.GetFilter())
            .Project(id.ParticipantOneId.GetChatProjection())
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<Chat?> GetByIdAsync(
        ChatId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task AddAsync(Chat entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .Chats
            .AddAsync(_chatsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<Chat> entities, CancellationToken cancellationToken)
    {
        await _chatsContext
            .Chats
            .AddRangeAsync(_chatsContext.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task DeleteAsync(Chat entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .Chats
            .DeleteAsync(
            _chatsContext.ClientSessionHandle,
            entity.Id.GetFilter(),
            cancellationToken);
    }
}
