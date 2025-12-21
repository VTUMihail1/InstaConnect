using InstaConnect.Common.Domain.Models;

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
        CommonSortingQuery<ChatByParticipantSortProperty> sorting,
        CommonPaginationQuery pagination,
        CommonIncludeQuery<ChatIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var match = Builders<Chat>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.ParticipantOneId.Id, filter.ParticipantId.Id)
            .OrEqualsCaseInsensitive(p => p.Id.ParticipantOneId.Id, filter.ParticipantId.Id)
            .AndOptionalStartsWithCaseInsensitive(p => p.ParticipantOne!.Name.Value, filter.ParticipantName.IsEmpty(), filter.ParticipantName.Value)
            .OrOptionalStartsWithCaseInsensitive(p => p.ParticipantTwo!.Name.Value, filter.ParticipantName.IsEmpty(), filter.ParticipantName.Value);

        var projection = Builders<Chat>.Projection.Expression(
            c => new Chat(c.Id.ParticipantOneId.Id.ToLower() == filter.ParticipantId.Id.ToLower()
                                              ? c.Id : new(c.Id.ParticipantTwoId, c.Id.ParticipantOneId),
                          c.CreatedAtUtc));

        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _chatSortPropertyFactory.Create(sorting.Property);
        var sort = Builders<Chat>.Sort.Combine(
            Builders<Chat>.Sort.Ascending(c => c.CreatedAtUtc),
            sortOrder.Sort(sortProperty.Property));
        var includeProperties = _chatIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _chatsContext
            .Chats
            .Aggregate()
            .Includes(includeProperties)
            .Match(match);

        var totalCount = (int)await _chatsContext.Chats.CountDocumentsAsync(match, cancellationToken: cancellationToken);

        var entities = await pipeline
            .Project(projection)
            .Sort(sort)
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var collectionEntities = _chatCollectionFactory.Create(entities, totalCount, pagination);

        return collectionEntities;
    }

    public async Task<Chat?> GetByIdAsync(
        ChatId id,
        CommonIncludeQuery<ChatIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var match = Builders<Chat>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.ParticipantOneId.Id, id.ParticipantOneId.Id)
            .OrEqualsCaseInsensitive(p => p.Id.ParticipantTwoId.Id, id.ParticipantOneId.Id)
            .AndEqualsCaseInsensitive(p => p.Id.ParticipantOneId.Id, id.ParticipantTwoId.Id)
            .OrEqualsCaseInsensitive(p => p.Id.ParticipantTwoId.Id, id.ParticipantTwoId.Id);

        var projection = Builders<Chat>.Projection.Expression(
            c => new Chat(c.Id.ParticipantOneId.Id.ToLower() == id.ParticipantOneId.Id.ToLower()
                                              ? c.Id : new(c.Id.ParticipantTwoId, c.Id.ParticipantOneId),
                          c.CreatedAtUtc));

        var includeProperties = _chatIncludePropertyFactory.Create(include?.Properties);

        var entity = await _chatsContext
            .Chats
            .Aggregate()
            .Includes(includeProperties)
            .Match(match)
            .Project(projection)
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
        var match = Builders<Chat>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.ParticipantOneId.Id, entity.Id.ParticipantOneId.Id)
            .OrEqualsCaseInsensitive(p => p.Id.ParticipantTwoId.Id, entity.Id.ParticipantOneId.Id)
            .AndEqualsCaseInsensitive(p => p.Id.ParticipantOneId.Id, entity.Id.ParticipantTwoId.Id)
            .OrEqualsCaseInsensitive(p => p.Id.ParticipantTwoId.Id, entity.Id.ParticipantTwoId.Id);

        await _chatsContext
            .Chats
            .DeleteAsync(
            _chatsContext.ClientSessionHandle,
            match,
            cancellationToken);
    }
}
