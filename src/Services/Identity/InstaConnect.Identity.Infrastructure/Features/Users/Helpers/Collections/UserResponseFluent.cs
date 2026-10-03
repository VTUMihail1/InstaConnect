using InstaConnect.Common.Domain.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Collections;

public class UserResponseFluent :
	MongoDbResponseFluent<UserResponse>, IUserResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IUsersSortTermerFactory _sortTermerFactory;

	public UserResponseFluent(
		IPaginator paginator,
		IAggregateFluent<UserResponse> fluent,
		ISortOrdererFactory sortOrdererFactory,
		IUsersSortTermerFactory sortTermerFactory) : base(fluent)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
	}

	public IUserResponseFluent ApplySorting(UsersSortingQuery query)
	{
		ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IUserResponseFluent ApplyPagination(UsersPaginationQuery query)
	{
		ApplyPagination(_paginator, query);

		return this;
	}
}
