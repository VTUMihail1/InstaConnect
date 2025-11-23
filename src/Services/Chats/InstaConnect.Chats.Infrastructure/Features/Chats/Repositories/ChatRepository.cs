using System.Collections.Generic;

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
        var isParticipantNameEmpty = filter.ParticipantName.IsEmpty();

        var pipeline = _chatsContext
            .Chats
            .Aggregate()
            .Includes(includeProperties)
            .Match(p =>  p.Id.HasUser(filter.ParticipantId) &&
                         (isParticipantNameEmpty ||
                         p.ParticipantOne!.Name.StartsWith(filter.ParticipantName) ||
                         p.ParticipantTwo!.Name.StartsWith(filter.ParticipantName)));

        var totalCountsResult = await pipeline.Count().FirstOrDefaultAsync(cancellationToken);

        var entities = await pipeline
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var collectionEntities = _chatCollectionFactory.Create(entities, (int)totalCountsResult.Count, pagination);

        return collectionEntities;
    }

    public async Task<Chat?> GetByIdAsync(
        ChatId id,
        ChatIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _chatIncludePropertyFactory.Create(include?.Properties);

        var entity = await _chatsContext
            .Chats
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id.Is(id))
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

    public async Task DeleteAsync(Chat entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .Chats
            .DeleteAsync(
            _chatsContext.ClientSessionHandle,
            x => x.Id.Is(entity.Id),
            cancellationToken);
    }
}
