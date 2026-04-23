using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Common.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Repositories;

internal class ChatMessageQueryRepository : IChatMessageQueryRepository
{
    private readonly IPaginator _paginator;
    private readonly IChatsContext _context;
    private readonly ISortOrdererFactory _sortOrdererFactory;
    private readonly IChatMessagesSortTermerFactory _sortTermerFactory;
    private readonly IChatIncludeBuilderFactory _includeBuilderFactory;
    private readonly IChatMessageIncluderFactory _messageIncluderFactory;
    private readonly IChatMessageIncludeBuilderFactory _messageIncludeBuilderFactory;

    public ChatMessageQueryRepository(
        IPaginator paginator,
        IChatsContext context,
        ISortOrdererFactory sortOrdererFactory,
        IChatIncludeBuilderFactory includeBuilderFactory,
        IChatMessagesSortTermerFactory sortTermerFactory,
        IChatMessageIncluderFactory messageIncluderFactory,
        IChatMessageIncludeBuilderFactory messageIncludeBuilderFactory)
    {
        _paginator = paginator;
        _context = context;
        _sortOrdererFactory = sortOrdererFactory;
        _includeBuilderFactory = includeBuilderFactory;
        _sortTermerFactory = sortTermerFactory;
        _messageIncluderFactory = messageIncluderFactory;
        _messageIncludeBuilderFactory = messageIncludeBuilderFactory;
    }

    public async Task<ICollection<ChatMessageResponse>> GetAllAsync(
        ChatMessagesFilterQuery filter,
        CurrentUserQuery currentUser,
        ChatMessagesSortingQuery sorting,
        ChatMessagesPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        var messageInclude = _messageIncludeBuilderFactory.Create().WithSender().Build();

        return await _context
            .ChatMessages
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_messageIncluderFactory, messageInclude)
            .Match(filter)
            .ProjectToResponseWithoutChat(currentUser)
            .Sort(_sortOrdererFactory, _sortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        ChatMessagesFilterQuery filter,
        CancellationToken cancellationToken)
    {
        var messageInclude = _messageIncludeBuilderFactory.Create().WithSender().Build();

        return await _context
            .ChatMessages
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_messageIncluderFactory, messageInclude)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<ChatMessageResponse?> GetByIdAsync(
        ChatMessageId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
        var messageInclude = _messageIncludeBuilderFactory.Create().WithSender().WithChat(include).Build();

        return await _context
            .ChatMessages
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_messageIncluderFactory, messageInclude)
            .Match(id)
            .ProjectToFullResponse(currentUser)
            .FirstOrDefaultAsync(cancellationToken);
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
