using InstaConnect.Common.Domain.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

public class ChatMessageResponseFluentFactory : IChatMessageResponseFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IChatMessagesSortTermerFactory _sortTermerFactory;

	public ChatMessageResponseFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IChatMessagesSortTermerFactory sortTermerFactory)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
	}

	public IChatMessageResponseFluent Create(IAggregateFluent<ChatMessageResponse> fluent)
	{
		return new ChatMessageResponseFluent(_paginator, fluent, _sortOrdererFactory, _sortTermerFactory);
	}
}
