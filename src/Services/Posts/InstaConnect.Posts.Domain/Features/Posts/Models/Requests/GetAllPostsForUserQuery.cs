namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record GetAllPostsForUserQuery(
    PostsForUserFilterQuery Filter,
    PostsSortingQuery Sorting,
    PostsPaginationQuery Pagination,
    CurrentUserQuery CurrentUser)
    : ISortableQuery<PostsSortingQuery, PostsSortTerm>, IPaginatableQuery<PostsPaginationQuery>, ICurrentUserableQuery;
