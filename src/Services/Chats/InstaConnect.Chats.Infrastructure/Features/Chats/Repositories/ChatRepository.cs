using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Repositories;

internal class ChatRepository : IChatRepository
{
    private readonly IPaginator _paginator;
    private readonly IChatsContext _chatsContext;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IChatCollectionFactory _chatCollectionFactory;
    private readonly IChatIncludePropertyFactory _chatIncludePropertyFactory;
    private readonly IChatByParticipantSortPropertyFactory _chatSortPropertyFactory;

    public ChatRepository(
        IPaginator paginator,
        IChatsContext chatsContext,
        ISortOrderFactory sortOrderFactory,
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
        ChatByParticipantSortingQuery sorting,
        ChatPaginationQuery pagination,
        ChatIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _chatSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _chatIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);
        var isParticipantNameEmpty = filter.ParticipantName.IsNullOrEmptyOrWhiteSpace();

        var pipeline = _chatsContext
            .Chats
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => (p.ParticipantOneId == filter.ParticipantId ||
                         p.ParticipantTwoId == filter.ParticipantId) &&
                         (isParticipantNameEmpty ||
                         p.ParticipantOne!.Name.StartsWithOrdinalIgnoreCase(filter.ParticipantName) ||
                         p.ParticipantTwo!.Name.StartsWithOrdinalIgnoreCase(filter.ParticipantName)));

        var totalCountsResult = await pipeline.Count().FirstOrDefaultAsync(cancellationToken);

        var entities = await pipeline
            .Project(a => new Chat(
                a.ParticipantOneId == filter.ParticipantId ? a.ParticipantOne! : a.ParticipantTwo!,
                a.ParticipantTwoId == filter.ParticipantId ? a.ParticipantTwo! : a.ParticipantOne!,
                a.CreatedAt,
                a.UpdatedAt))
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var collectionEntities = _chatCollectionFactory.Create(entities, (int)totalCountsResult.Count, pagination);

        return collectionEntities;
    }

    public async Task<Chat?> GetByIdAsync(
        string participantOneId,
        string participantTwoId,
        ChatIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _chatIncludePropertyFactory.Create(include?.Properties);

        var entity = await _chatsContext
            .Chats
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.ParticipantOneId == participantOneId && p.ParticipantTwoId == participantTwoId)
            .Project(a => new Chat(
                a.ParticipantOneId == participantOneId ? a.ParticipantOne! : a.ParticipantTwo!,
                a.ParticipantTwoId == participantOneId ? a.ParticipantTwo! : a.ParticipantOne!,
                a.CreatedAt,
                a.UpdatedAt))
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<Chat?> GetByIdAsync(
        string participantOneId,
        string participantTwoId,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(participantOneId, participantTwoId, null, cancellationToken);
    }

    public async Task AddAsync(Chat entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .Chats
            .AddAsync(_chatsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task UpdateAsync(Chat entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .Chats
            .UpdateAsync(
            _chatsContext.ClientSessionHandle,
            x => x.ParticipantOneId == entity.ParticipantOneId && x.ParticipantTwoId == entity.ParticipantTwoId,
            entity,
            cancellationToken);
    }

    public async Task DeleteAsync(Chat entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .Chats
            .DeleteAsync(
            _chatsContext.ClientSessionHandle,
            x => x.ParticipantOneId == entity.ParticipantOneId && x.ParticipantTwoId == entity.ParticipantTwoId,
            cancellationToken);
    }
}
