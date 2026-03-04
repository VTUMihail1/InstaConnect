using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Repositories;

internal class ChatQueryRepository : IChatQueryRepository
{
    private readonly IPaginator _paginator;
    private readonly IChatsContext _context;
    private readonly IChatIncluderFactory _includerFactory;
    private readonly ISortOrdererFactory _sortOrdererFactory;
    private readonly IChatsSortTermerFactory _sortTermerFactory;

    public ChatQueryRepository(
        IPaginator paginator,
        IChatsContext context,
        IChatIncluderFactory includerFactory,
        ISortOrdererFactory sortOrdererFactory,
        IChatsSortTermerFactory sortTermerFactory)
    {
        _paginator = paginator;
        _context = context;
        _includerFactory = includerFactory;
        _sortOrdererFactory = sortOrdererFactory;
        _sortTermerFactory = sortTermerFactory;
    }

    public async Task<ICollection<ChatResponse>> GetAllAsync(
        ChatsFilterQuery filter,
        CurrentUserQuery currentUser,
        ChatsSortingQuery sorting,
        ChatsPaginationQuery pagination,
        ChatInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Chats
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(filter)
            .ProjectToResponseWithoutParticipantOne(currentUser)
            .Sort(_sortOrdererFactory, _sortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<ChatResponse>> GetAllAsync(
        ChatsFilterQuery filter,
        CurrentUserQuery currentUser,
        ChatsSortingQuery sorting,
        ChatsPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await GetAllAsync(filter, currentUser, sorting, pagination, null, cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        ChatsFilterQuery filter,
        ChatInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Chats
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        ChatsFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await GetTotalCountAsync(filter, null, cancellationToken);
    }

    public async Task<ChatResponse?> GetByIdAsync(
        ChatId id,
        CurrentUserQuery currentUser,
        ChatInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Chats
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(id)
            .ProjectToFullResponse(currentUser)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<ChatResponse?> GetByIdAsync(
        ChatId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, currentUser, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        ChatId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .Chats
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .AnyAsync(cancellationToken);
    }
}
