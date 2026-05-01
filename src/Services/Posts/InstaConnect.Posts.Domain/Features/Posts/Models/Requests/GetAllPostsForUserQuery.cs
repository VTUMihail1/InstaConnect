using InstaConnect.Common.Domain.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record GetAllPostsForUserQuery(
	PostsForUserFilterQuery Filter,
	PostsForUserSortingQuery Sorting,
	PostsPaginationQuery Pagination,
	CurrentUserQuery CurrentUser)
	: ISortableQuery<PostsForUserSortingQuery, PostsForUserSortTerm>, IPaginatableQuery<PostsPaginationQuery>, ICurrentUserableQuery;
