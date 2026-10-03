using InstaConnect.Common.Domain.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

public class ChatMessageResponseFluent :
	MongoDbResponseFluent<ChatMessageResponse>, IChatMessageResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IChatMessagesSortTermerFactory _sortTermerFactory;

	public ChatMessageResponseFluent(
		IPaginator paginator,
		IAggregateFluent<ChatMessageResponse> fluent,
		ISortOrdererFactory sortOrdererFactory,
		IChatMessagesSortTermerFactory sortTermerFactory) : base(fluent)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
	}

	public IChatMessageResponseFluent ApplySorting(ChatMessagesSortingQuery query)
	{
		ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IChatMessageResponseFluent ApplyPagination(ChatMessagesPaginationQuery query)
	{
		ApplyPagination(_paginator, query);

		return this;
	}
}
