using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Identity.Application.Features.Users.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAll;

public record GetAllUsersQueryRequest(
	string FirstName,
	string LastName,
	string Name,
	string CurrentId,
	CommonSortOrder SortOrder,
	UsersSortTerm SortTerm,
	int Page,
	int PageSize)
	: IQueryRequest<GetAllUsersQueryResponse>, ISortableQueryRequest<UsersSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
