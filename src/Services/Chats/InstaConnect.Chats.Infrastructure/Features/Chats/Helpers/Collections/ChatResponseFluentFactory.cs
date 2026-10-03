using InstaConnect.Common.Domain.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

public class ChatResponseFluentFactory : IChatResponseFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IChatsSortTermerFactory _sortTermerFactory;

	public ChatResponseFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IChatsSortTermerFactory sortTermerFactory)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
	}

	public IChatResponseFluent Create(IAggregateFluent<ChatResponse> fluent)
	{
		return new ChatResponseFluent(_paginator, fluent, _sortOrdererFactory, _sortTermerFactory);
	}
}
