using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Posts.Application.Features.Users.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;

public record GetAllPostCommentsForUserQueryRequest(
	string UserId,
	string CurrentUserId,
	CommonSortOrder SortOrder,
	PostCommentsForUserSortTerm SortTerm,
	int Page,
	int PageSize)
	: IQueryRequest<GetAllPostCommentsForUserQueryResponse>, ISortableQueryRequest<PostCommentsForUserSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
