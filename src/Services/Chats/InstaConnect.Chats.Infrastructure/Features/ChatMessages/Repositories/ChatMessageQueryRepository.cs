using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Repositories;

internal class ChatMessageQueryRepository : IChatMessageQueryRepository
{
    private readonly IPaginator _paginator;
    private readonly IChatsContext _context;
    private readonly ISortOrdererFactory _sortOrdererFactory;
    private readonly IChatMessagesSortTermerFactory _sortTermerFactory;
    private readonly IChatMessageIncluderFactory _messageIncluderFactory;

    public ChatMessageQueryRepository(
        IPaginator paginator,
        IChatsContext context,
        ISortOrdererFactory sortOrdererFactory,
        IChatMessagesSortTermerFactory sortTermerFactory,
        IChatMessageIncluderFactory messageIncluderFactory)
    {
        _paginator = paginator;
        _context = context;
        _sortOrdererFactory = sortOrdererFactory;
        _sortTermerFactory = sortTermerFactory;
        _messageIncluderFactory = messageIncluderFactory;
    }

    public async Task<ICollection<ChatMessageResponse>> GetAllAsync(
        ChatMessagesFilterQuery filter,
        CurrentUserQuery currentUser,
        ChatMessagesSortingQuery sorting,
        ChatMessagesPaginationQuery pagination,
        ChatMessageInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .ChatMessages
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_messageIncluderFactory, include)
            .Match(filter)
            .ProjectToFullResponse(currentUser)
            .Sort(_sortOrdererFactory, _sortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<ChatMessageResponse>> GetAllAsync(
        ChatMessagesFilterQuery filter,
        CurrentUserQuery currentUser,
        ChatMessagesSortingQuery sorting,
        ChatMessagesPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await GetAllAsync(filter, currentUser, sorting, pagination, null, cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        ChatMessagesFilterQuery filter,
        ChatMessageInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .ChatMessages
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_messageIncluderFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        ChatMessagesFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await GetTotalCountAsync(filter, null, cancellationToken);
    }

    public async Task<ChatMessageResponse?> GetByIdAsync(
        ChatMessageId id,
        CurrentUserQuery currentUser,
        ChatMessageInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .ChatMessages
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_messageIncluderFactory, include)
            .Match(id)
            .ProjectToFullResponse(currentUser)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<ChatMessageResponse?> GetByIdAsync(
        ChatMessageId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, currentUser, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        ChatMessageId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .ChatMessages
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .AnyAsync(cancellationToken);
    }
}
