using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Users.Extensions;
using InstaConnect.Common.Domain.Features.Data.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Repositories;

internal class ChatQueryRepository : IChatQueryRepository
{
	private readonly IPaginator _paginator;
	private readonly IChatsContext _context;
	private readonly IChatIncluderFactory _includerFactory;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IChatsSortTermerFactory _sortTermerFactory;
	private readonly IChatIncludeBuilderFactory _includeBuilderFactory;

	public ChatQueryRepository(
		IPaginator paginator,
		IChatsContext context,
		IChatIncluderFactory includerFactory,
		ISortOrdererFactory sortOrdererFactory,
		IChatsSortTermerFactory sortTermerFactory,
		IChatIncludeBuilderFactory includeBuilderFactory)
	{
		_paginator = paginator;
		_context = context;
		_includerFactory = includerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<ICollection<ChatResponse>> GetAllAsync(
		ChatsFilterQuery filter,
		CurrentUserQuery currentUser,
		ChatsSortingQuery sorting,
		ChatsPaginationQuery pagination,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();

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

	public async Task<long> GetTotalCountAsync(
		ChatsFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();

		return await _context
			.Chats
			.AggregateWithCaseInsensitiveCollation()
			.Includes(_includerFactory, include)
			.Match(filter)
			.GetCount(cancellationToken);
	}

	public async Task<ChatResponse?> GetByIdAsync(
		ChatId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();

		return await _context
			.Chats
			.AggregateWithCaseInsensitiveCollation()
			.Includes(_includerFactory, include)
			.Match(id)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);
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
